# TicTacToe

Simple 3x3 TicTacToe against a bot.  
Built from scratch to practice **MVC pattern** in Unity.

---

## Play Online

You can try the game directly in your browser:  
👉 [Play on itch.io](https://kadzy.itch.io/tictactoe)

[![Play TicTacToe on itch.io](https://github.com/user-attachments/assets/2ff4d788-0efb-4ff1-ba59-6ed5164326cb)](https://kadzy.itch.io/tictactoe)

---

## Screenshot

![ScreenShot_20250925055755](https://github.com/user-attachments/assets/0dff40be-86f9-4487-b6a0-471e10d4d1a4)

---

## Architecture

This project follows the **MVC (Model-View-Controller) pattern**:

- **Models**: Store game data and state (`BoardModel`, `CellModel`)
- **Views**: Handle visual representation (`CellView`, UI components)
- **Controllers**: Manage logic and coordinate between Models and Views (`BoardController`, `CellController`, `GameManager`)

### Key Components

- **GameManager**: Singleton managing overall game state and events
- **BoardController**: Handles board logic, move validation, and win checking
- **PlayerTurnManager**: Manages turn-based gameplay
- **BotMovement**: Simple bot that makes random valid moves
- **WinChecker**: Detects winning conditions and draw states

---

### Controls

- **Mouse Click**: Click on an empty cell to place your mark (X)
- The bot (O) will automatically make its move after yours


## Project Structure

```
Assets/
├── Scripts/
│   ├── Board/ 
│   │   ├── BoardController.cs
│   │   ├── BoardModel.cs
│   │   ├── BoardBuilder.cs
│   │   ├── BotMovement.cs
│   │   └── WinChecker.cs
│   ├── Cell/ 
│   │   ├── CellController.cs
│   │   ├── CellModel.cs
│   │   └── CellView.cs
│   ├── Constants/ 
│   │   ├── CellValue.cs
│   │   ├── CellWinStatus.cs
│   │   └── GameStatus.cs
│   ├── Managers/ 
│   │   ├── GameManager.cs
│   │   └── PlayerTurnManager.cs
│   └── UI/ 
│       ├── DisplayWinner.cs
│       └── PlayerUIHighlighter.cs
├── Scenes/
├── Prefabs/
└── Resources/ 
```

---

## How to Run Locally

### Prerequisites

- **Unity Editor** `6000.3.2f1` or compatible

### Setup Instructions

1. Clone the repository:
   ```bash
   git clone https://github.com/kadzyly/TicTacToe.git
   cd TicTacToe
   ```
2. Open the game scene `Assets/Scenes/GameScene.unity`
3. Press **Play** to start the game
