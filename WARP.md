# WARP.md

This file provides guidance to WARP (warp.dev) when working with code in this repository.

## Project Overview

Deal Dash is a browser-based HTML5 Canvas delivery car game with 10 levels and fire boost power.

**Live:** https://dealdash2025.netlify.app

## Files

```
DealDash/
├── index.html    # The entire game (single file)
├── README.md     # Documentation
└── WARP.md       # This file
```

## Development

```bash
# Open game locally
start index.html

# Or use live server
npx serve .
```

## Code Architecture

The game is a single `index.html` file (~1000 lines) with embedded CSS and JavaScript.

### Key Components

- **Level System** - 10 levels with unique road layouts, colors, and difficulty
- **Car Physics** - Simple 2D physics with acceleration, friction, steering
- **Collision System** - Building collision detection with push-out
- **Boost System** - Unlimited fire boost for speed and phasing through buildings
- **Weather Effects** - Rain particles (snow on level 7)
- **Touch Controls** - Mobile-responsive with on-screen buttons

### Game Loop

```
gameLoop()
  ├── updateBoost(dt)      # Manage boost timer
  ├── updateCar(dt)        # Physics, collision, fire trail
  ├── checkPackages()      # Package collection
  ├── checkPowerups()      # Power-up collection
  ├── updateRain()         # Weather particles
  ├── updateUI()           # Timer, level, score display
  └── draw*()              # Render all elements
```

### Level Configuration

Levels are defined in the `levels` array:
```javascript
{ name, packages, time, bg, road, carColor, carName }
```

Each level has a `generateLevel()` switch case for road layout.

## Deployment

Hosted on Netlify. Auto-deploys from GitHub on push to main.

To deploy elsewhere, just host `index.html` - no build step needed.
