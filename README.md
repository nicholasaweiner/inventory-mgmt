# Inventory Management Application


# Changelog 
All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/).

## [Unreleased]
- `EditItem.cs`
  - Select item using short GUID or select from list of items attributed to user's name or item's location
  - View and overwrite item details
- `RemoveItem.cs`
  - Select item to remove using GUID or select from list of items attributed to user's name or item's location
- `BrowseItems.cs`
  - Filter `userItemData.json` based on items attributed to user's name or item's location, or view all items
- Web-Based User Interface (Blazor or Vue)

## [0.0.2] - 07-29-2022

### Added
- Return to Main Menu method for `EditItem.cs` , `RemoveItem.cs` and `BrowseItems.cs`

### Changed
- `AddItem.cs`
  - Returning to Main Menu feature
  
### Fixed
- `AddItem.cs`
  - JSON Serializer before Exit.Run() with Console.Clear()

## [0.0.1] - 07-27-2022
### Added
- Code Louisville Requirements
  - Implement a “master loop” console application where the user can repeatedly enter commands/perform actions, including choosing to exit the program
    - Example: `ExitProgram.cs`, `MainMenuReturn.cs`
  - Create an additional class which inherits one or more properties from its parent
    - Example: `program.cs` (Line 9)
  - Create a dictionary or list, populate it with several values, retrieve at least one value, and use it in your program
    - Example: `ApplicationCommands.cs` (Line 69)
  - Read data from an external file, such as text, JSON, CSV, etc and use that data in your application
    - Example: `ApplicationCommands.cs` (Lines 12-27)  
  - Use a LINQ query to retrieve information from a data structure (such as a list or array) or file
   - Example: `AddItem.cs` (Lines 55-60)

### Changed
- `README.md` for [Keep a Changelog](https://keepachangelog.com/en/1.0.0/) formatting.

### Fixed
- `AddItem.cs`
  - Enter item Type's name or number in order to create item
