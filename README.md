# Cursed Knight

**Cursed Knight** is a dark fantasy dungeon-crawling deckbuilder prototype built in Unity.  
The player balances raw steel and forbidden power, risking corruption to unleash devastating attacks.

---

## High Concept

Cursed Knight is a turn-based deckbuilder where players begin as a pure knight and gradually embrace corruption through powerful reward cards. Each combat encounter forces a decision: play safe, or risk triggering a devastating **Curse Surge**.

---

## Core Mechanics

### Combat Rules
- Player starts with **60 HP**
- Draw **5 cards per turn**
- Gain **3 Energy per turn**
- Block reduces incoming damage and resets each turn
- When the draw pile is empty → shuffle discard pile into draw pile
- At the start of each combat → shuffle the full deck

### Corruption System
- Corruption starts at **0**
- Only certain reward cards generate corruption
- At **10 Corruption → Curse Surge**
  - Lose 8 HP
  - Corruption resets to 0

Corruption represents forbidden strength. The more it is used, the closer the knight comes to collapse.

---

## Starting Deck (10 Cards)

| Card           | Cost | Effect                         | Copies |
|---------------|------|--------------------------------|--------|
| Rusty Sword   | 1    | Deal 6 Damage                  | 4      |
| Broken Shield | 1    | Gain 5 Block                   | 4      |
| Focus         | 0    | Gain 1 Energy, +1 Corruption   | 2      |

The starting deck is intentionally weak to encourage meaningful upgrades.

---

## Reward System

After each fight:
1. 3 random cards are selected from a reward pool of 8
2. The player selects 1 card
3. The selected card is added to the discard pile
4. Duplicates are allowed across the run

### Run Structure
- 3 normal encounters
- 1 Boss encounter

---

## Enemies

### Crypt Rat
- HP: 25
- Attacks for 6 every turn

### Bone Soldier
- HP: 35  
- Turn 1: Attack 8  
- Turn 2: Defend 6  
- Repeat  

### Hollow Brute
- HP: 45  
- Turn 1: Attack 10  
- Turn 2: Charge (+6 next attack)  
- Turn 3: Attack 16  
- Repeat  

### Boss — Chainbound Knight
- HP: 85  
- Attack Pattern: 10 → 12 → 18 → Repeat  
- At 40 HP: Enrage (+2 damage to all attacks)

---

## Tech Stack

- Unity (2D)
- C#
- ScriptableObjects for Card and Enemy data
- Git for version control

---

## Development Status
- Corruption scaling bonuses


## License

This project is currently a prototype and not licensed for commercial distribution.---
- Dungeon map system
- Visual polish
- Card removal & upgrades

- Card archetypes
Planned for future versions:

- Enemy patterns defined
Prototype Phase:
- Corruption mechanic implemented
- Reward system implemented

