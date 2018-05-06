using System;
using System.Text.RegularExpressions;

namespace SikuliSharp
{
	public interface ISikuliSession : IDisposable
	{
		bool Exists(IPattern pattern, float timeoutInSeconds = 0);
		bool Click(IPattern pattern);
		bool Click(IPattern pattern, Point offset);
		bool DoubleClick(IPattern pattern);
		bool DoubleClick(IPattern pattern, Point offset);
		bool Wait(IPattern pattern, float timeoutInSeconds = 0);
		bool WaitVanish(IPattern pattern, float timeoutInSeconds = 0);
		bool Type(string text);
        bool DragAndDrop(IPattern pattern, IPattern pattern2);
        bool Hover(IPattern pattern);
    }

	public class SikuliSession : ISikuliSession
	{
		private static readonly Regex InvalidTextRegex = new Regex(@"[\r\n\t\x00-\x1F]", RegexOptions.Compiled);
		private readonly ISikuliRuntime _runtime;
		
		public SikuliSession(ISikuliRuntime sikuliRuntime)
		{
			_runtime = sikuliRuntime;
			_runtime.Start();
		}

        public bool Hover(IPattern pattern)
        {
            return RunCommand("hover", pattern, 0);
        }

        public bool DragAndDrop(IPattern pattern, IPattern pattern2)
        {
            return RunCommand2Param("dragDrop", pattern, pattern2, 0);
        }

        public bool Exists(IPattern pattern, float timeoutInSeconds = 0f)
		{
			return RunCommand("exists", pattern, timeoutInSeconds);
		}

		public bool Click(IPattern pattern)
		{
			return RunCommand("click", pattern, 0);
		}

		public bool Click(IPattern pattern, Point offset)
		{
			return RunCommand("click", new WithOffsetPattern(pattern, offset), 0);
		}
		
		public bool DoubleClick(IPattern pattern)
		{
			return RunCommand("doubleClick", pattern, 0);
		}

		public bool DoubleClick(IPattern pattern, Point offset)
		{
			return RunCommand("doubleClick", new WithOffsetPattern(pattern, offset), 0);
		}

		public bool Wait(IPattern pattern, float timeoutInSeconds = 0f)
		{
			return RunCommand("wait", pattern, timeoutInSeconds);
		}

		public bool WaitVanish(IPattern pattern, float timeoutInSeconds = 0f)
		{
			return RunCommand("waitVanish", pattern, timeoutInSeconds);
		}

		public bool Type(string text)
		{
			if(InvalidTextRegex.IsMatch(text))
				throw new ArgumentException("Text cannot contain control characters. Escape them before, e.g. \\n should be \\\\n", "text");

			var script = string.Format(
				"print \"SIKULI#: YES\" if type(\"{0}\") == 1 else \"SIKULI#: NO\"",
				text
				);

			var result = _runtime.Run(script, "SIKULI#: ", 0d);
			return result.Contains("SIKULI#: YES");
		}

		protected bool RunCommand(string command, IPattern pattern, float commandParameter)
		{
			pattern.Validate();

			var script = string.Format(
				"print \"SIKULI#: YES\" if {0}({1}{2}) else \"SIKULI#: NO\"",
				command,
				pattern.ToSikuliScript(),
				ToSukuliFloat(commandParameter)
				);

			var result = _runtime.Run(script, "SIKULI#: ", commandParameter * 1.5d); // Failsafe
			return result.Contains("SIKULI#: YES");
		}

        protected bool RunCommand2Param(string command, IPattern pattern, IPattern pattern2, float commandParameter)
        {
            pattern.Validate();

            var script = string.Format(
                "print \"SIKULI#: YES\" if {0}({1}{3},{2}{3}) else \"SIKULI#: NO\"",
                command,
                pattern.ToSikuliScript(),
                pattern2.ToSikuliScript(),
                ToSukuliFloat(commandParameter)
                );

            var result = _runtime.Run(script, "SIKULI#: ", commandParameter * 1.5d); // Failsafe
            return result.Contains("SIKULI#: YES");
        }


        private static string ToSukuliFloat(float timeoutInSeconds)
		{
			return timeoutInSeconds > 0f ? ", " + timeoutInSeconds.ToString("0.####") : "";
		}

		public void Dispose()
		{
			_runtime.Stop();
		}
	}
}
