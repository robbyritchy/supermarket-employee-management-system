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
            <td>Interface 1/td>
            <td>IHourLogger.cs</td>
            <td>All</td>
            <td>IHourLogger defines methods for HourLogger.cs to 
            follow, and allows for future expandability if needed.
            </td>
        </tr>
    </tbody>
</table>