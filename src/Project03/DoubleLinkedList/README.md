# DoubleLinkedList Demo

This project demonstrates a generic doubly linked list in C# using cookie brand health data.

## Features
- Generic doubly linked list implementation (`DoublyLinkedList<T>`, `Node<T>`) with add, insert, remove, move, swap, and enumeration operations
- Domain model: `Cookie` with brand, calories, ingredients, sugar, grain type, and gluten-free flag
- Example usage in `Program.cs` showing all operations and console output
- Comprehensive NUnit unit tests (see `UnitTesting/DoubleLinkedListTests.cs`)

## Build & Run

```powershell
# Build
cd src/Project03/DoubleLinkedList
 dotnet build DoubleLinkedList.csproj

# Run demo
 dotnet run --project DoubleLinkedList.csproj

# Run tests (from repo root)
 dotnet test UnitTesting/UnitTesting.csproj
```

## Example Output
```
After AddLast:
Forward:
  [0] ChocoCrunch | 200 cal | Sugar: 12.5g | Grain: Wheat | GlutenFree: False
  [1] OatBite | 150 cal | Sugar: 8g | Grain: Oat | GlutenFree: False
  [2] SugarSnap | 220 cal | Sugar: 15g | Grain: Rice | GlutenFree: True
Backward:
  [0] SugarSnap | 220 cal | Sugar: 15g | Grain: Rice | GlutenFree: True
  [1] OatBite | 150 cal | Sugar: 8g | Grain: Oat | GlutenFree: False
  [2] ChocoCrunch | 200 cal | Sugar: 12.5g | Grain: Wheat | GlutenFree: False
...
```

## Notes
- All list operations are node-based for correctness with duplicate values.
- Edge cases (empty list, invalid node, etc.) are handled with exceptions.
- See `Program.cs` for a step-by-step demo.
