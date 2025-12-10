# WARP.md

This file provides guidance to WARP (warp.dev) when working with code in this repository.

## Project Overview

Deal Dash is a Unity 3D delivery car game. Drive a sedan through a rainy city delivering 5 packages within 10 minutes.

**Engine:** Unity 2021.3 LTS or newer

## Development Commands

```powershell
# Open project in Unity (adjust path to your Unity installation)
& "C:\Program Files\Unity\Hub\Editor\2021.3.x\Editor\Unity.exe" -projectPath "C:\Users\CARLOS\Desktop\JACOB\CARS\DealDash"
```

Unity operations (build, test, play) are done through the Unity Editor GUI - no CLI build system.

## Code Architecture

~190 lines across 4 scripts in `Assets/Scripts/`:

```
GameManager (Singleton)
    ↓ notifies
UIManager ←────────── updates timer/counter UI
    
CarController ─────── handles input, physics, audio, camera
    
PackageDelivery ────→ GameManager.DeliverPackage()
```

### Script Responsibilities

- **GameManager.cs** - Singleton managing game state. Owns `timeRemaining`, `packagesDelivered`, `gameActive`. Calls `UIManager` on state changes. `DeliverPackage(points)` is the entry point for scoring.

- **CarController.cs** - Attached to player car. Uses Unity's WheelCollider system (rear-wheel drive). Handles WASD/Space input in `Update()`, applies physics in `FixedUpdate()`. Also controls main camera follow with shake effect.

- **UIManager.cs** - Receives calls from GameManager to update legacy UI Text elements. No logic of its own.

- **PackageDelivery.cs** - Self-contained delivery markers. Creates its own Point Light on Start if none exists. Calls `GameManager.Instance.DeliverPackage()` on trigger collision with "Player" tag, then self-destructs.

### Key Patterns

- GameManager uses singleton via `Instance` property
- Car must be tagged "Player" for package collision detection
- WheelColliders must be assigned in inspector (frontLeft, frontRight, rearLeft, rearRight)
- Center of mass is lowered (`y: -0.5`) for stability

## Configuration

Adjustable via Unity Inspector:

| Component | Field | Default | Purpose |
|-----------|-------|---------|---------|
| GameManager | gameDuration | 600 | Timer in seconds |
| GameManager | totalPackages | 5 | Win condition |
| CarController | motorPower | 1500 | Acceleration |
| CarController | wheelGrip | 0.8 | Tire traction |
| CarController | cameraDistance | 6 | Chase cam distance |
| PackageDelivery | pointsPerDelivery | 100 | Score per package |

## Scene Setup Requirements

See `SETUP.md` for detailed instructions. Critical elements:

1. Car GameObject needs Rigidbody (Mass: 1200) + 4 WheelCollider children
2. Package markers need BoxCollider with "Is Trigger" enabled
3. Canvas with timerText and deliveryCountText UI elements
4. Rain particle system positioned above play area

## Asset Dependencies

External assets required (not included in repo):
- Car model (.fbx)
- City/building assets
- Audio clips: engine loop, tire squeal, rain ambient, delivery sound
- Wet asphalt textures

See `ASSETS.md` for free asset recommendations from Unity Asset Store and Kenney.nl.
