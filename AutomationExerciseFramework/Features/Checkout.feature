Feature: Checkout
	

@mytag
Scenario: User can make an order
	 Given user opens sign in page
       And enters "Lea" name and valid email address
       And user clicks on SignUp button
     When user fills in all required fields
       And submits the signUp form
     Then user will get "Account Created!" success message
       And user will be logged in
	 Given user opens products page
	   And searches for "Winter Top" term
	   And opens first search result
	 When user clicks on Add to Cart button 
	   And proceeds to cart
	 Then shopping cart will be displayed with expected product inside
	 When user clicks on Proceed to checkout button
	  And enters some comment
	  And clicks on Place order button
	  And fills all required fields
	 Then user receives message "Congratulations! Your order has been confirmed!"