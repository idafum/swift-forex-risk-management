# Swift - Forex Risk Management
## Overview
In forex trading, risk management is often touted as the the cornerstone of success. 
However, when it comes to real-time trade execution, traders frequently struggle to adhere to the golden rule of risking only 1-2% of their account per trade. 
This challenge is compounded by the time-sensitive nature of market execution and lack of proper tools for lot size calculation during limit order setups.

The Swift Risk Management Calculator (SRMC) aims to bridge this gap by providing traders with a simple, effective,
and data-driven solution to manage risk and optimize their trading decisions.

## Architecture
This app uses a **3-Tier Architecture**
### Frontend (UI & MVVM Layer)
- This handles user interaction
- .NET MAUI (XAML, ViewModels)
### Backend (Businedd Logic Layer)
- Process requests, applies businedd logic, and interact with the data layer.
- C# services and managers
### Data Layer (SQLite)
- Handles database operations, ensures data consistency


