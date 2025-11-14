# TicTacToe (Unity Learning Project)

A simple **single-player TicTacToe game** made with Unity.  
The main goals of this project were:
- ✅ Build a small game **from scratch to release**
- ✅ Practice using the **MVC (Model–View–Controller) pattern** in Unity

---

## 🎮 Play Online

You can try the game directly in your browser:  
👉 [Play on itch.io](https://kadzy.itch.io/tictactoe)

[![Play TicTacToe on itch.io](https://github.com/user-attachments/assets/2ff4d788-0efb-4ff1-ba59-6ed5164326cb)](https://kadzy.itch.io/tictactoe)

---

## 🖼️ Screenshot

![ScreenShot_20250925055755](https://github.com/user-attachments/assets/0dff40be-86f9-4487-b6a0-471e10d4d1a4)

---

## 🛠️ Features

- Classic **3x3 TicTacToe gameplay**
- **Single-player mode** with a simple bot opponent
- **Win/Draw detection** system with visual feedback
- **Turn-based gameplay** with player turn management
- **UI highlighting** for active player
- **Game state management** (InGame, Win, Loss, Draw)
- Minimal UI built with Unity's **Canvas system** and **TextMeshPro**
- Exported as **WebGL build** for browser play

---

## 🏗️ Architecture

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

## 📁 Project Structure

```
Assets/
├── Scripts/
│   ├── Board/          # Board logic and management
│   │   ├── BoardController.cs
│   │   ├── BoardModel.cs
│   │   ├── BoardBuilder.cs
│   │   ├── BotMovement.cs
│   │   └── WinChecker.cs
│   ├── Cell/           # Individual cell components
│   │   ├── CellController.cs
│   │   ├── CellModel.cs
│   │   └── CellView.cs
│   ├── Constants/      # Game constants and enums
│   │   ├── CellValue.cs
│   │   ├── CellWinStatus.cs
│   │   └── GameStatus.cs
│   ├── Managers/       # Game management systems
│   │   ├── GameManager.cs
│   │   └── PlayerTurnManager.cs
│   └── UI/             # User interface components
│       ├── DisplayWinner.cs
│       └── PlayerUIHighlighter.cs
├── Scenes/
│   └── GameScene.unity # Main game scene
├── Prefabs/
│   └── CellPrefab.prefab
└── Resources/          # Game assets
```

---

## 🚀 How to Run Locally

### Prerequisites

- **Unity Editor**: Version `6000.2.10f1` or compatible
- Git (for cloning)

### Setup Instructions

1. Clone the repository:
   ```bash
   git clone https://github.com/kadzyly/TicTacToe.git
   cd TicTacToe
   ```

2. Open the project in Unity:
   - Launch Unity Hub
   - Click "Open" and select the `TicTacToe` folder
   - Unity will import the project (may take a few minutes)

3. Open the game scene:
   - Navigate to `Assets/Scenes/GameScene.unity`
   - Double-click to open the scene

4. Press ▶️ **Play** to start the game

### Controls

- **Mouse Click**: Click on an empty cell to place your mark (X)
- The bot (O) will automatically make its move after yours

---

## 🛠️ Technologies & Packages

- **Unity Version**: 6000.2.10f1
- **Render Pipeline**: Universal Render Pipeline (URP) 17.2.0
- **Input System**: Unity Input System 1.14.2
- **UI Framework**: Unity UI (uGUI) 2.0.0
- **Text Rendering**: TextMeshPro
- **Build Target**: WebGL

### Key Dependencies

- `com.unity.render-pipelines.universal`: Universal Render Pipeline
- `com.unity.inputsystem`: New Input System
- `com.unity.ugui`: Unity UI system
- `com.unity.feature.2d`: 2D features support

---

## 📚 What I Learned

- How to structure a Unity project with **MVC pattern**
- Basics of **C# scripting** in Unity
- Setting up a UI with **Canvas, Panels, and Buttons**
- Implementing **game state management** (in progress, win, draw)
- Working with **Unity Events** and **C# Actions** for decoupled communication
- **Singleton pattern** implementation for managers
- **Coroutines** for delayed bot moves
- Exporting and publishing a **WebGL build** to itch.io
- Using **namespaces** for better code organization

---

## 🎯 Game Rules

1. Players take turns placing their mark (X for player, O for bot)
2. The player always goes first
3. First to get 3 marks in a row (horizontal, vertical, or diagonal) wins
4. If all 9 cells are filled with no winner, it's a draw
5. Click the restart button to play again

---

## 📝 License

This project is created for learning purposes. Feel free to use and modify as needed.


