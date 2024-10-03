# Unity Tool: Level Generation System

## Table of Contents
1. [Overview](#overview)
2. [Setup](#setup)
3. [Usage Instructions](#usage-instructions)
4. [Design Patterns](#design-patterns)
5. [Extensibility](#extensibility)

## Overview

This Unity Tool is a Level Generation System designed to create and display interactive levels with images, questions, and multiple-choice answers. It's built to be easily extensible and configurable through ScriptableObjects.

## Setup

### 1. Scene Hierarchy

Create the following hierarchy in your Unity scene:

```
GameController
LevelGenerator
UICanvas
└── LevelDisplay
    ├── QuestionImage
    ├── QuestionText
    └── OptionsContainer
```

### 2. ScriptableObjects

Create LevelConfig ScriptableObjects for each level (e.g., Level1_Easy, Level2_Medium, Level3_Hard).

### 3. Script Assignments

- Attach `GameController` script to the GameController GameObject
- Attach `LevelGenerator` script to the LevelGenerator GameObject
- Attach `LevelController` script to the UICanvas/LevelDisplay GameObject

### 4. Inspector Setup

Configure the following in the Unity Inspector:

- **GameController**:
  - Assign LevelController and LevelGenerator references
- **LevelGenerator**:
  - Add LevelConfig ScriptableObjects
  - Set number of levels to generate
- **LevelController**:
  - Assign references for QuestionImage, QuestionText, and OptionsContainer

### 5. Image Setup

Prepare three images for each level:
1. Question Image: Displayed at the start of the question
2. Correct Answer Image: Shown when the correct answer is selected
3. Incorrect Answer Image: Displayed when an incorrect answer is chosen

## Usage Instructions

1. Create LevelConfig ScriptableObjects for each desired level type
2. Configure each LevelConfig with:
   - Question Image
   - Correct Answer Image
   - Incorrect Answer Image
   - Word options
   - Correct words
   - Question text
3. Add created LevelConfigs to the LevelGenerator component
4. Set the desired number of levels to generate
5. Run the scene

The system will automatically:
- Generate levels based on the provided configs
- Display images, questions, and options for each level
- Handle user input and level progression

## Design Patterns

1. **Factory Pattern**: Used in `LevelFactory` to create `Level` objects from `LevelConfig` ScriptableObjects.

2. **Command Pattern**: Implicitly used in option selection handlers for answer checking and level progression.

3. **Observer Pattern**: Likely used for updating UI elements and managing game state changes.

4. **Singleton**: Possibly used for the GameController (not explicitly shown, but common in Unity projects).

5. **ScriptableObject Architecture**: Used for flexible and reusable level configurations.

## Extensibility

The system is designed for easy expansion:

1. Create new LevelConfig ScriptableObjects for additional level types
2. Add new images for different question types or feedback
3. Extend the LevelController to handle new types of interactions or display elements
4. Modify the GameController to include additional game logic or scoring systems

By following this structure, you can easily add new levels, question types, or gameplay mechanics without significant changes to the core system.

### Implementing Animations

While this system uses static images, it can be easily adapted to use animations:

1. Replace the `QuestionImage` with an animated component (e.g., using Unity's Animation system or a third-party solution).
2. Update the `LevelConfig` ScriptableObject to include references to animation clips instead of static images.
3. Modify the `LevelController` to trigger animations instead of swapping images.

This flexibility allows you to enhance the visual feedback of the system without major structural changes.
