# Sales Order Management Web App

This web application is designed to manage sales order data, providing a user-friendly interface for viewing, updating, and creating orders, windows, and elements.

## Table of Contents

- [Requirements](#requirements)
- [Test Data](#test-data)
- [Source Code](#source-code)
  - [Instructions](#instructions)
- [Contributing](#contributing)

## Requirements

1. **Database Setup:**
   - Create new database tables using Code First in Entity Framework.

2. **Web App:**
   - Develop a Blazor WebAssembly app with an interface to display data from the database.

3. **Data Management:**
   - Allow users to change and save data in the application, specifically for the order's state, name, and dimensions.

4. **Order Management:**
   - Provide functionality to create and delete orders, windows, and elements.

5. **Optional Enhancements:**
   - Implement interface validations.
   - Use Data Transfer Objects (DTO).
   - Separate Business Logic Layer (BLL) and Data Access Layer (DAL) projects.

## Test Data

The following XML structure provides test data for storing into the database:

```xml
<Orders>
    <Order Name="New York Building 1" State="NY">
        <Windows>
            <Window Name="A51" QuantityOfWindows="4" TotalSubElements="3">
                <SubElements>
                    <SubElement Element="1" Type="Doors" Width="1200" Height="1850" />
                    <SubElement Element="2" Type="Window" Width="800" Height="1850" />
                    <SubElement Element="3" Type="Window" Width="700" Height="1850" />
                </SubElements>
            </Window>
            <Window Name="C Zone 5" QuantityOfWindows="2" TotalSubElements="1">
                <SubElements>
                    <SubElement Element="1" Type="Window" Width="1500" Height="2000" />
                </SubElements>
            </Window>
        </Windows>
    </Order>
    <Order Name="California Hotel AJK" State="CA">
    </Order>
</Orders>
<Windows>
    <Window Name="GLB" QuantityOfWindows="3" TotalSubElements="2">
        <SubElements>
            <SubElement Element="1" Type="Doors" Width="1400" Height="2200" />
            <SubElement Element="2" Type="Window" Width="600" Height="2200" />
        </SubElements>
    </Window>
    <Window Name="OHF" QuantityOfWindows="10" TotalSubElements="2">
        <SubElements>
            <SubElement Element="1" Type="Window" Width="1500" Height="2000" />
            <SubElement Element="1" Type="Window" Width="1500" Height="2000" />
        </SubElements>
    </Window>
</Windows>
```
## Source Code

The source code for the application is included in this repository. Follow the instructions below to run and test the application.

### Instructions

- Clone the repository to your local machine.
- Set up the database using Code First in Entity Framework.
- Build and run the Blazor WebAssembly app.
- Test the application, ensuring all functionalities work as expected.

## Contributing

Contributions are welcome! Please follow the contribution guidelines for details.

##  Screenshots

![image (17)](https://github.com/nkutechologies/Blazor-Code-Smaple/assets/71810407/0a29de11-2f09-4b03-a6e8-a8f9bef8f5a5)


![image (16)](https://github.com/nkutechologies/Blazor-Code-Smaple/assets/71810407/e59ed274-449e-4258-a2f1-9295a5a48cd1)


