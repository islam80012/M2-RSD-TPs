# Systèmes Distribués — TP OMNeT++

## Description
Introduction to network simulation using OMNeT++ and C++.

## TP2 Exercises
- **Tic-Toc:** Message exchange between two nodes.
- **Jeton:** Token passing between five nodes in a unidirectional ring. The token stops after 3 complete tours.

## Files
- `tictoc.ned` — Network topology
- `Noeud.cc` — Node implementation
- `Noeud.h` — Node declaration
- `omnetpp.ini` — Simulation configuration

## How to Run
1. Import the project into OMNeT++.
2. Build the project.
3. Select `Tictoc` or `Jeton` in `omnetpp.ini`.
4. Run the simulation.

## TP3 Exercises 
1. Create RoutageMsg.msg first .
2. Build project to generate files RoutageMsg_m.h and RoutageMsg_m.cc
3. than add Noeud.cc
4. Noeud.h is unchanged for now .
