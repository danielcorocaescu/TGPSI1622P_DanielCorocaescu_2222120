# TGPSI1622P_DanielCorocaescu_2222120
CashControl

Table of Contents
Description
Technologies
How To Use
Implementation
Development Timeline
Technical Aspects
References
License
Author Info
Description
CashControl is a personal financial management application designed to help users record, view, edit, and delete incomes and expenses. The application is built using C# and Windows Forms, with a backend database managed by SQL Server (SSMS). The primary language of the application is English.

Technologies
Programming Language: C#
Framework: Windows Forms
Database: SQL Server (SSMS)
IDE: Visual Studio
How To Use
To use this application, follow these steps:

Clone the repository to your local machine.
Open the solution file in Visual Studio.
Build and run the application.
Use the login screen to access the main dashboard.
From the dashboard, you can manage your incomes and expenses through various functionalities provided.
Implementation
Development Timeline

Technical Aspects
Project Requirements:
REQ001: Mandatory login (user must have an account).
REQ002: Create expenses and incomes.
REQ003: Read expenses and incomes.
REQ004: Update expenses and incomes.
REQ005: Delete expenses and incomes.
REQ006: View incomes.
REQ007: View expenses.
REQ008: Dashboard page for financial analysis.
REQ009: Set language to English.
Data Model:
Entities and Relationships Diagrams (ER):
Income: IncomeName, IncomeCategory, IncomeAmount, IncomeDate
Expense: ExpenseName, ExpenseCategory, ExpenseAmount, ExpenseDate
Account: LoginUser, NomeApelido, UserEmail, NumeroTLF
Login: LoginUser, LoginPassword
User Interface Examples:
Login: Mandatory login screen for all users.
Dashboard: Displays total incomes, total expenses, number of transactions.
Income.cs: Record incomes (IncomeName, IncomeCategory, IncomeAmount, IncomeDate).
Expenses.cs: Record expenses (ExpenseName, ExpenseCategory, ExpenseAmount, ExpenseDate).
ViewExpenses.cs: View, edit, and delete expenses.
ViewIncome.cs: View, edit, and delete incomes.
Account.cs: View account details and change email and phone number.
References
ChatGPT
Image Resizer
FlatIcon
JumpShare
YouTube Tutorial
License
This project is licensed under the MIT License.

Author Info
Daniel Alexandre Corocaescu, nº2222120
