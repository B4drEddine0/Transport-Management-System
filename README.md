# MESQ-AMIN Transport Management System

## Overview

This comprehensive transportation management system was developed for MESQ-AMIN SARL, a company specializing in national and international road freight transport. The application streamlines the management of various aspects of the transport business, including vehicle tracking, voyage management, financial operations, client management, driver management, and more.

## Features

### Dashboard
- Real-time statistics on voyages, payments, expenses, and profits
- Daily reminders for driver and vehicle maintenance
- Intuitive navigation to all system modules

### Client Management
- Create, edit, and delete client profiles
- Store client information (name, address, contact details)
- Track client transaction history

### Product Management
- Add, modify, and remove products
- Track product information (nature, weight, description)
- Inventory management

### Driver Management
- Comprehensive driver profiles (personal information, licenses, documents)
- Track driver status and availability
- Salary management
- Maintenance reminders

### Vehicle Management
- Track vehicle information (model, registration number, insurance)
- Maintenance scheduling and history
- Refrigeration unit management
- Vehicle reminders for maintenance and inspections

### Voyage Management
- Create, edit, and delete voyage records
- Track voyage details (departure/arrival cities, dates, status)
- Associate voyages with clients, products, vehicles, and drivers
- Real-time tracking with tracking numbers

### Expense Management
- Record voyage-related expenses (fuel, tolls, maintenance)
- Driver salary tracking
- Comprehensive expense categorization (transit fees, parking, market fees)

### Invoice and Payment Management
- Generate invoices for completed voyages
- Different invoice types for national (with 20% VAT) and international (no VAT) transport
- Payment tracking and status updates
- Multiple payment method support

### Real-time Tracking
- Interactive map interface for tracking voyages
- Detailed journey logs with step-by-step route information
- Status updates for ongoing voyages

### Reporting and Analytics
- Generate performance reports
- Financial analysis tools
- Export functionality for data extraction

### System Administration
- User management with role-based access control
- Action journal for admin to monitor user activities
- Data backup and restoration capabilities
- Theme customization options

## Technical Details

### Technologies Used

#### Programming Languages
- C# (Core application development)
- HTML/CSS (User interface)
- JavaScript (Interactive features and mapping)
- SQL (Database management)

#### Development Tools
- Microsoft Visual Studio (Main application development)
- Visual Studio Code (Web components)
- SQL Server Management Studio (Database management)
- GitHub (Version control)
- StarUML (Data modeling)

#### Database
- SQL Server database with comprehensive data model
- Structured around 13 main tables including:
  - Employees
  - Clients
  - Products
  - Drivers
  - Vehicles
  - Refrigeration units
  - Voyages
  - Expenses
  - Maintenance
  - Reminders
  - Invoices
  - Payments

### Architecture
- Windows Forms application for the main interface
- Web components for tracking system
- Three-tier architecture (presentation, business logic, data access)
- Crystal Reports integration for report generation

## Installation

1. **Database Setup**
   - Run the SQL scripts in the `Database` folder to create the database schema
   - Configure the connection string in the application config file

2. **Application Installation**
   - Run the installer package from the `Setup` folder
   - Follow the on-screen instructions to complete the installation

3. **Configuration**
   - Launch the application and log in with the default admin credentials
   - Configure system settings according to your business requirements

## Usage

### Login
- Use your username and password to access the system
- Reset password functionality available if needed

### Navigation
- Use the sidebar menu to navigate between different modules
- Dashboard provides quick access to key information and statistics

### Managing Voyages
1. Navigate to the Voyage section
2. Use the Add button to create a new voyage
3. Fill in all required information (client, product, vehicle, driver, etc.)
4. Save the voyage to generate a tracking number

### Tracking
1. Go to the Tracking section
2. Enter the tracking number in the search box
3. View the real-time location and journey details on the interactive map

### Generating Invoices
1. Navigate to the Invoice section
2. Select the invoice type (National or International)
3. Choose the voyage number
4. Click Search to generate the invoice
5. Review and print or export the invoice as needed

## Support

For technical support or feature requests, please contact:
- Email: badrdine03@gmail.com
- Github : B4drEddine0

## Credits

Developed by Badr Eddine MASSA AL KHAYR as part of a final project for professional training in Computer Development.

## License

This software is proprietary and confidential. Unauthorized copying, distribution, or use is strictly prohibited.

© 2023-2024 MESQ-AMIN SARL. All rights reserved.
