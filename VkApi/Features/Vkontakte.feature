Feature: Vkontakte

Scenario Outline: User log in 
	Given I navigate to site
		When I enter '<Login>' login and '<Password>' password
		And I click button 'Войти' 
			Then I stay on the page with '<NameOfTitle>' title
Examples:
| NameOfTitle         | Password                                    | Login                    |
| Добро пожаловать    |                                             |                          |
| Добро пожаловать    | 1qwawerxtcy                                 |                          |
| Добро пожаловать    |                                             | trhfdgchbjk              |
| Вход                | dfxcgfghlhkgfxbfcngvhbvvjcfxfxhxgfxgxhgfxhf | hghkfhfyf76of8fff        |
| Вход                | hghkfhfyf76of8fff                           | hghkfhfyf76of8fff        |
| Тестировщик Отбогов | PuV6j_.2&amp;$m9h?UY                        | autoperftester@gmail.com |

Scenario: Add and Edit post with attach uploaded image through api
	Given I navigate to site

		When I enter 'autoperftester@gmail.com' login and 'PuV6j_.2&amp;$m9h?UY' password
		And I click button 'Войти' 
			Then I move to user profile page

		When I navigate to 'Моя Страница'
		And Create post with randomly generated text on the wall and get the record id from the response
			Then Not updating the page, post exist on the wall with the right text from the right user

		When Change the text and add picture the post through the API request
			Then Without updating the page, message should be changed and the uploaded image should be added

		When Using the API request, add a comment to the post with random text
			Then Not updating the page,comment from the right user should be added to the correct post

		When Add Like for the record
			Then Through the request to the API, Like should be sent from the right user

		When  delete the created record
			Then Not updating the page, the entry should be deleted 
			And Delete created info by test

		When I click profile menu
		And I click button 'Выйти'

Scenario Outline: Serach user
	Given I navigate to site

		When I enter 'autoperftester@gmail.com' login and 'PuV6j_.2&amp;$m9h?UY' password
		And I click button 'Войти' 
			Then I move to user profile page

		When I navigate to 'Друзья'
		And click to Extended configuration
		And select '<Country>' region
		And enter the '<Name>' name of person
			Then all persons should have '<Name>' name

		When click to user according existing photo '<PhotoName>'
			Then the user must be true
		
		When I click profile menu
		And I click button 'Выйти'

Examples:
| PhotoName | Country  | Name             |
| sasha.jpg | Беларусь | Ховрин Александр |

Scenario Outline: Add interests of user
	Given I navigate to site

		When I enter '<Login>' login and '<Password>' password
		And I click button 'Войти' 
			Then I move to user profile page
		When I navigate to 'Моя Страница'
		When I click edit info about user button
		And navigate to 'Интересы' from right menu
		And fill info about Intrests in fields and save this changing

		When I navigate to 'Моя Страница'
		And click show full information button 
			Then all info Intrests equals true info

		When I click edit info about user button
		And navigate to 'Интересы' from right menu
		And clear info about Intrests in fields and save this changing

		When I navigate to 'Моя Страница'
		And click show full information button 
			Then all info Intrests equals true info
		When I click profile menu
		And I click button 'Выйти'

Examples:
| Password             | Login                    |
| PuV6j_.2&amp;$m9h?UY | autoperftester@gmail.com |

Scenario Outline: Add main info of user
	Given I navigate to site

		When I enter '<Login>' login and '<Password>' password
		And I click button 'Войти' 
			Then I move to user profile page
		When I navigate to 'Моя Страница'
		When I click edit info about user button
		And navigate to 'Основное' from right menu
		And fill info about Main in fields and save this changing

		When I navigate to 'Моя Страница'
		And click show full information button 
			Then all info Main equals true info

		When I click edit info about user button
		And navigate to 'Основное' from right menu
		And clear info about Main in fields and save this changing

		When I navigate to 'Моя Страница'
		And click show full information button 
			Then all info Main equals true info
		When I click profile menu
		And I click button 'Выйти'

Examples:
| Password             | Login                    |
| PuV6j_.2&amp;$m9h?UY | autoperftester@gmail.com |

Scenario Outline: Add contact info of user
	Given I navigate to site

		When I enter '<Login>' login and '<Password>' password
		And I click button 'Войти' 
			Then I move to user profile page
		When I navigate to 'Моя Страница'
		When I click edit info about user button
		And navigate to 'Контакты' from right menu
		And fill info about Contacts in fields and save this changing

		When I navigate to 'Моя Страница'
		And click show full information button 
			Then all info Contacts equals true info

		When I click edit info about user button
		And navigate to 'Контакты' from right menu
		And clear info about Contacts in fields and save this changing

		When I navigate to 'Моя Страница'
		And click show full information button 
			Then all info Contacts equals true info
		When I click profile menu
		And I click button 'Выйти'

Examples:
| Password             | Login                    |
| PuV6j_.2&amp;$m9h?UY | autoperftester@gmail.com |