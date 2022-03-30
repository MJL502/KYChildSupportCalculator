Welcome to the Kentucky Child SUpport Calculator.

This project helps people estimate child support in the state of Kentucky.
It navigates the user through easy to understand prompts.
It determines which of the child support formulas should apply based on the user inputs.
It then runs the correct child support calculation and outputs the child support amount.
It should take less than 5 minutes to run a complete child support calculation.

There are validations to ensure user input is in the correct form.
There is a master loop so the user can run as many calculations as they would like before exiting the program.

The state of Kentucky puts out a table that is occasionally updated.  
Across the top row is the number of children, beginning with 1 and ending with 6+.  
Down the left column it has totalMonthlyIncome in $100 increments, from $0 to $30,000.  
The program will round the parents totalMonthlyIncome to the correct $100 increment and then use that amount and the number of children to lookup the baseChildSupport.  
The child support table that is used in the calculation is read in from an external .csv file.
This allows the file to be easily replaced with an updated version if/when the state updates the child support table.

This project is run from a .NET console application, written in c#.
Ideally there would be a more user friendly interface and likely something cross platform.
Both are likely coming in a future version.
This project had specific parameters that necessitated the first version being built as a .NET console application.


Project Requirements
•	Project is uploaded to your GitHub repository and shows at minimum 5 separate commits. - Complete

•	Project includes a README file that explains the following:
	o	A one paragraph or longer description of what your project is about
	o	Which 3+ features you have included from the below list to meet the requirements
	o	Any special instructions required for the reviewer to run your project.
	COMPLETE

•	You must create at least one class, then create at least one object of that class and populate it with data. 
	You must use or display the data in your application. - COMPLETE - One example is the Parent class which has objects ParentOne and ParentTwo, both populated with data.

•	Create and call at least 3 functions or methods, at least one of which must return a value that is used in your application.
	- COMPLETE -

•	Choose at least 3 items on the Features List below and implement them in your project

FEATURE LIST:
1	Implement a “master loop” console application where the user can repeatedly enter commands/perform actions, including choosing to exit the program
	 COMPLETE

2	Read data from an external file, such as text, JSON, CSV, etc and use that data in your application 	Complete - the child support table is read in frmo a csv file

3	Create 3 or more unit tests for your application - Complete 

4	Build a conversion tool that converts user input to another type and displays it (ex: converts cups to grams) - Complete - the program converts user inputs (i.e. monthly income and number of children) into a child support amount

5	Calculate and display data based on an external factor (ex: get the current date, and display how many days remaining until some event) - Complete - I have a timer that starts when the user begins inputing data and finishes when the program is complete, and displays how long it took to run the program

6	Create a dictionary or list, populate it with several values, retrieve at least one value, and use it in your program - POSSIBLY COMPLETE? - I CREATE AN ARRAY (not a dictionary or list) and retreive a value from it


Features which are not included but could be added in the future:

•	Create an additional class which inherits one or more properties from its parent

•	Implement a log that records errors, invalid inputs, or other important events and writes them to a text file

•	Implement a regular expression (regex) to ensure a field either a phone number or an email address is always stored and displayed in the same format 

•	Use a LINQ query to retrieve information from a data structure (such as a list or array) or file

•	Analyze text and display information about it (ex: how many words in a paragraph)

•	Visualize data in a graph, chart, or other visual representation of data
