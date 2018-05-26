Feature: Vkontakte

Background: 
		Given I navigate to site
		When I enter ' autoperftester@gmail.com ' login and 'PuV6j_.2&amp;$m9h?UY' password
		And I click button 'Войти' 
			Then I move to user profile page

Scenario: Add and Edit post with attach uploaded image through api

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

		When I navigate to 'Моя Страница'
		When I click edit info about user button
		And navigate to '<TabName>' from right menu
		And fill info about '<TabName>' in fields and save this changing

		When I navigate to 'Моя Страница'
		And click show full information button 
			Then all info '<TabName>' equals true info

		When I click edit info about user button
		And navigate to '<TabName>' from right menu
		And clear info about '<TabName>' in fields and save this changing

		When I navigate to 'Моя Страница'
		And click show full information button 
			Then all info '<TabName>' equals true info
		When I click profile menu
		And I click button 'Выйти'

Examples:
| TabName           |
| Интересы          |
| Основное          |
| Контакты          |
| Образование       |
| Карьера           |
| Военная служба    |
| Жизненная позиция |
