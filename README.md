# Memory-Efficient Shooter Prototype

## Overview
This Unity prototype demonstrates object pooling as a memory
optimization technique compared to traditional object spawning.

## Gameplay Feature
- Object pooling for projectiles
- Reduced garbage collection overhead
- Stable memory usage during gameplay

##
- Enemy shoots ate you while you try to collect objects and avoid spikes

## Gameplay Flowchart

[Game Start]
      ↓
[Initialize Object Pool]
      ↓
[Spawn Player & Enemy]
      ↓
[Gameplay Loop]
      ↓
[Player Input Detected]
      ↓
[Player Movement]
      ↓
[Central Enemy Shoots (Pooled Projectiles)]
      ↓
[Collision Check]
   ┌───────────────┬────────────────┐
   │               │                │
[Collectible]   [Hazard Hit]   [Projectile Hit]
   │               │                │
[Increase Score] [Reduce Health] [Reduce Health]
   │               │                │
[Deactivate Item]   └──────┬────────┘
      ↓                   ↓
[Return to Gameplay Loop] [Health <= 0?]
                              ↓ Yes
                          [Game Over]

## How to Run
1. Open the project in Unity
2. Load the MainScene
3. Press Play

## Gameplay Logic
Projectiles are reused instead of destroyed, reducing memory
allocations and garbage collection spikes.

## Video Demo
[Insert your video link]

## GitHub Link
[Insert repository link]
