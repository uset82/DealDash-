# Deal Dash - Required Assets

## Free Assets from Unity Asset Store

### Car Model
**Recommended Free Options:**
1. **Simple Cars - Cartoon Vehicles** by VeryHotShark
   - Free realistic sedan included
   - URL: Unity Asset Store search "Simple Cars"

2. **Free Low Poly Vehicles** by Kenney
   - Clean low-poly sedan model
   - URL: https://kenney.nl/assets/car-kit

3. **Arcade Free Racing Car** by Mena
   - Good for arcade-style feel
   - Search "Arcade Free Racing Car" on Asset Store

### City/Environment
**Recommended Free Options:**
1. **Simple Town - Cartoon Assets** by Synty Studios
   - Free version available
   - Buildings, streets, props included

2. **Low Poly City Pack** (Various Publishers)
   - Search "Low Poly City Free" on Asset Store
   - Look for packs with street/road assets

3. **Modular Building Set** by Unity
   - Create custom buildings
   - Standard Assets may include basics

### Weather Effects
1. **Rain Maker** by Tasharen
   - Free rain particle system
   - Or create custom (see SETUP.md)

2. **Particle Pack** by Unity
   - Standard Assets > ParticleSystems
   - Rain and weather effects included

### Textures
1. **Yughues Free Ground Materials**
   - Asphalt and road textures
   - Free on Asset Store

2. **Free PBR Materials** (Various)
   - Search for "Asphalt PBR Free"
   - Wet asphalt variations available

### Audio Assets
**Engine Sounds:**
1. **Car Sound Effects Pack** by MGW Sound Design
   - Free version available
   - Includes engine loops

2. **Vehicle Sound FX** (Various free options)
   - Search "Free Car Sounds" on Asset Store

**Tire Sounds:**
1. **Free Sound Effects Pack** by Olivier Girardot
   - Includes tire squeal sounds

**Rain Sounds:**
1. **Ambient Nature Sounds** (Various)
   - Rain loops often included
   - Search "Rain Ambient Free"

2. **Free Sound Effects** by Little Robot Sound Factory
   - Weather sounds included

**Delivery/UI Sounds:**
1. **UI Sound Pack** by Kenney
   - https://kenney.nl/assets/interface-sounds
   - Confirmation/success sounds

## Alternative Sources (Free)

### Freesound.org
- Engine hum: search "car engine loop"
- Tire squeal: search "tire screech"
- Rain: search "rain ambient"
- Wind: search "wind driving"

### OpenGameArt.org
- Various free car models (Blender export)
- City environment assets
- Sound effects

### Kenney.nl
- Massive free game asset library
- Cars, buildings, UI elements
- High quality, no attribution required

## Manual Asset Creation

### If Creating Your Own Assets:

**Car (Simple):**
- Use Unity primitives (cubes, cylinders)
- Parent objects for wheel positions
- Apply basic materials

**Streets:**
- Unity planes with scaled dimensions
- Dark material with high smoothness
- Tiled asphalt texture

**Buildings:**
- Simple cubes with window textures
- Various heights and widths
- Basic emissive materials for lit windows

**Rain Particles:**
- Unity Particle System
- White/light blue particles
- Fast downward velocity
- High emission rate

## Asset Import Checklist

- [ ] Sedan car model (.fbx or .obj)
- [ ] Street/road textures (albedo + normal)
- [ ] Building models or prefabs
- [ ] Engine sound loop (.wav or .mp3)
- [ ] Tire squeal sound (.wav or .mp3)
- [ ] Rain ambient loop (.wav or .mp3)
- [ ] Delivery success sound (.wav or .mp3)
- [ ] Rain particle texture (optional)
- [ ] Skybox (overcast/cloudy)

## Unity Built-in Assets
Some assets can come from Unity Standard Assets:
- Character Controller components
- Basic particle systems
- Simple audio clips (limited)

**Note:** Standard Assets package may need to be imported from Package Manager or downloaded separately in newer Unity versions.
