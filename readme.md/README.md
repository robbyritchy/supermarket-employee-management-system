# supermarket-employee-management-system
<h1>Project Overview</h1>
<p>The goal of our project is to develop a centralized, and modular
    employee interface that businesses could use and tailor for their
    employees to use. We wanted managers to be able to access multiple
    responsibilities from within the app, and for regular employees to
    be able to see their responsibilities. We took some inspiration 
    from old jobs where outdated methods were used to keep track of 
    employees, so we felt that we could take steps to create a modular
    design and fix these common issues.</p>
<h1>Build and Run Instructions</h1>
<p>The project runs on C#, Net 9.0 on Rider. Simply clone the 
project from GitHub directly, and it will run.</p>
<h1>Required OOP Features</h1>
<table>
    <thead>
        <tr>
            <th>OOP Features</th>
            <th>File Name</th>
            <th>Line Number</th>
            <th>Reasoning/Purpose</th>
        </tr>
    </thead>
    <tbody>
        <tr>
            <td>Inheritance 1</td>
            <td>Manager.cs/td>
            <td>All</td>
            <td>Manager inherits common behavior from Employee</td>
        </tr>
        <tr>
            <td>Inheritance 2</td>
            <td>Stocker.cs</td>
            <td>All</td>
            <td>Stocker inherits common behavior from Employee</td>
        </tr>
        <tr>
            <td>Inheritance 3</td>
            <td>Cashier.cs</td>
            <td>All</td>
            <td>Cashier inherits common behavior from Employee</td>
        </tr>
        <tr>
            <td>Interface 1</td>
            <td>IHourLogger.cs</td>
            <td>All</td>
            <td>IHourLogger defines methods for HourLogger.cs to 
            follow, and allows for future expandability if needed.
            </td>
        </tr>
        <tr>
            <td>Interface 2</td>
            <td>IManageEmployees.cs</td>
            <td>All</td>
            <td>Defines methods for manager class to control employees
                such as hire,fire, and edit them.
            </td>
        </tr>
        <tr>
            <td>Interface 3</td>
            <td>IWork.cs</td>
            <td>All</td>
            <td>Defines methods for employee subclasses to follow, 
                including getting job descriptions and tasks. 
            </td>
        </tr>
        <tr>
            <td>Polymorphism 1</td>
            <td>PayByCash.cs/PayByCheck.cs/PayByDirectDeposit.cs</td>
            <td>5-14</td>
            <td>The payment classes each override methods defined
                by abstract class Paycheck to define their own way
                to pay employees.
            </td>
        </tr>
        <tr>
            <td>Polymorphism 2</td>
            <td>Employee.cs / Manager.cs</td>
            <td>18-25</td>
            <td>Manager overrides CalculatePay and GetPayInfo
                methods from Employee to calculate and return 
                payment information.
            </td>
        </tr>
        <tr>
            <td>Access Modifier</td>
            <td>Manager.cs</td>
            <td>5</td>
            <td>The Employee dictionary is set to private
                for security purposes, and to ensure only the 
                manager class can access employee information.
            </td>
        </tr>
        <tr>
            <td>Struct</td>
            <td>WorkLogEntry.cs</td>
            <td>All</td>
            <td>Adds the date and number of entries when a work
                log needs to be added to the hour logger.
            </td>
        </tr>
        <tr>
            <td>Enum 1</td>
            <td>JobType.cs</td>
            <td>All</td>
            <td>Holds the different job types, used when manager
                attempts to change an employees job.
            </td>
        </tr>
        <tr>
            <td>Enum 2</td>
            <td>PayMethod.cs</td>
            <td>All</td>
            <td>Holds the different types of payment methods, also
                used when manager attempts to change an employees
                preferred payment type.
            </td>
        </tr>
        <tr>
            <td>Data Structure</td>
            <td>Supermarket.cs</td>
            <td>6</td>
            <td>Defines a dictionary to hold a key value pair
                of employee ids, and employee instances. Allows for 
                quick look up and management of employees.
            </td>
        </tr>
        <tr>
            <td>I/O</td>
            <td>Program.cs</td>
            <td>All</td>
            <td>Console UI that contains a login/logout function
                for managers and regular employees (cashier/stocker),
                From the UI, employees can be managed, and job 
                descriptions and tasks can be viewed, along with hours.
            </td>
        </tr>
    </tbody>
</table>

<h1>Design Patterns</h1>
<table>
    <thead>
        <tr>
            <th>Pattern Name</th>
            <th>Category</th>
            <th>File Name</th>
            <th>Line Numbers</th>
            <th>Rationale</th>
        </tr>
    </thead>
    <tbody>
    </tbody>
</table>