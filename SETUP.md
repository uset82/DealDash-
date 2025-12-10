# Deal Dash - Unity Scene Setup Guide

## Scene Configuration

### 1. Create New Scene
1. In Unity, create a new scene: `File > New Scene > 3D`
2. Save it as `MainGame` in `Assets/Scenes/`

### 2. Lighting Setup (Rainy Evening Atmosphere)
1. **Directional Light** (Main Light)
   - Color: Slightly blue-gray `RGB(180, 190, 200)`
   - Intensity: 0.5 (dim for rainy weather)
   - Rotation: X: 45°, Y: -30°, Z: 0°

2. **Environment Lighting**
   - Window > Rendering > Lighting Settings
   - Skybox: Use default or dark cloudy skybox
   - Ambient Color: Dark gray `RGB(100, 100, 110)`
   - Fog: Enable
     - Color: Light gray `RGB(150, 150, 160)`
     - Density: 0.02

### 3. City Map Setup
1. **Ground/Streets**
   - Create 3D Plane objects for streets
   - Scale to create 3 intersecting streets
   - Apply wet asphalt material (see Materials section)
   - Add Box Collider for physics

2. **Buildings**
   - Place simple building models along streets
   - Use free assets from Unity Asset Store
   - Suggested: Simple low-poly building packs
   - Spacing: Leave room for car navigation

3. **City Layout Example**
   ```
   Street 1: North-South (100m x 10m)
   Street 2: East-West (100m x 10m)
   Street 3: Diagonal cross street (80m x 10m)
   ```

### 4. Car Setup
1. **Import Car Model**
   - Import realistic sedan model (see ASSETS.md)
   - Tag as "Player"
   - Add Rigidbody component
     - Mass: 1200
     - Drag: 0.05
     - Angular Drag: 0.5

2. **Wheel Colliders**
   - Add 4 child GameObjects for wheels: FrontLeft, FrontRight, RearLeft, RearRight
   - Add WheelCollider to each
     - Radius: 0.35
     - Suspension Distance: 0.2
     - Spring: 35000
     - Damper: 4500
     - Force App Point: -0.2

3. **Camera Target**
   - Create empty GameObject as child of car
   - Name: "CameraTarget"
   - Position: Behind car, slightly elevated
   - Position: (0, 0.5, -2)

4. **Audio Sources**
   - Add 3 AudioSource components to car
   - Engine Sound: Loop enabled, volume 0.6
   - Tire Squeal: Loop disabled, volume 0.8
   - Rain Sound: Loop enabled, volume 0.3

5. **Attach Scripts**
   - Add `CarController.cs` script
   - Assign wheel colliders in inspector
   - Assign audio sources
   - Assign camera target transform

### 5. Package Markers Setup
1. Create 5 package delivery points
2. For each package:
   - Create Cube GameObject (scale: 1, 1, 1)
   - Position at different street locations
   - Add Box Collider, enable "Is Trigger"
   - Add `PackageDelivery.cs` script
   - Assign delivery sound (optional)

### 6. Weather Effects
1. **Rain Particle System**
   - Create Particle System GameObject
   - Name: "RainSystem"
   - Position above play area (Y: 20)
   - Settings:
     - Emission Rate: 500
     - Start Lifetime: 2
     - Start Speed: 10
     - Start Size: 0.1
     - Gravity Modifier: 2
     - Shape: Box (cover entire map)
     - Color: Light blue-white

2. **Wet Asphalt Effect**
   - See Materials section below

### 7. Materials Setup
1. **Wet Asphalt Material**
   - Create new Material in `Assets/Materials/`
   - Name: "WetAsphalt"
   - Shader: Standard
   - Albedo: Dark gray `RGB(40, 40, 45)`
   - Metallic: 0.3
   - Smoothness: 0.8 (reflective when wet)
   - Normal Map: Optional asphalt texture

2. **Package Marker Material**
   - Create new Material: "PackageGlow"
   - Shader: Standard
   - Albedo: Yellow `RGB(255, 255, 0)`
   - Emission: Yellow `RGB(255, 255, 0)`
   - Enable emission

### 8. UI Setup
1. **Canvas**
   - Create UI Canvas (right-click Hierarchy > UI > Canvas)
   - Render Mode: Screen Space - Overlay

2. **Timer Text**
   - Create UI Text (child of Canvas)
   - Position: Top-left (X: -600, Y: 450)
   - Font Size: 36
   - Color: White
   - Text: "10:00"

3. **Delivery Counter Text**
   - Create UI Text (child of Canvas)
   - Position: Top-left (X: -600, Y: 400)
   - Font Size: 32
   - Color: White
   - Text: "Deals: 0/5"

4. **Create UIManager**
   - Create empty GameObject: "UIManager"
   - Add `UIManager.cs` script
   - Assign timer and delivery text references

### 9. Game Manager Setup
1. Create empty GameObject: "GameManager"
2. Add `GameManager.cs` script
3. Configure in inspector:
   - Game Duration: 600 (10 minutes)
   - Total Packages: 5

### 10. Camera Setup
1. Main Camera will be controlled by CarController
2. Initial position: (0, 3, -8)
3. Tag: "MainCamera"

### 11. Physics Settings (Optional Tuning)
- Edit > Project Settings > Physics
- Default Material: Create physics material with:
  - Dynamic Friction: 0.6
  - Static Friction: 0.6
  - Bounciness: 0.1

### 12. Audio Import
- Import audio files into `Assets/Audio/`
- Set audio clips on car AudioSources
- Rain sound on ambient audio source

## Testing the Scene
1. Press Play
2. Use WASD to drive
3. Space to brake
4. Drive to yellow glowing packages
5. Watch timer and delivery count

## Performance Tips
- Use occlusion culling for city
- LOD groups for distant buildings
- Limit particle count if FPS drops
- Bake lighting for better performance

## Troubleshooting
- **Car doesn't move**: Check wheel collider assignments
- **No audio**: Verify AudioSource components and clips assigned
- **UI not visible**: Check Canvas render mode and camera
- **Packages don't trigger**: Verify "Player" tag on car and trigger enabled on packages
