# TP-M8--Asterix  
🎯 Mini-projet C# — Système de gestion de réservations (Application Console)

## Réalisé par Whitchy AUGUSTIN, Wanguy CALVERT et Momnsen MEREUS

## 📘 Contexte du projet

Ce projet a été réalisé dans le cadre d’un **cours intensif de programmation C# ** à la **Faculté des Sciences (FDS)**.  
Il répond à une demande client visant à **simplifier la gestion de ressources partagées et de leurs réservations**, à l’aide d’une **application console simple, claire et structurée**.

Aucune base de données ni interface graphique n’était requise :  
👉 toutes les données sont **conservées en mémoire**.

---

## 🧠 Objectif du programme

Le programme permet de :

- Gérer des **ressources partagées** (salles, équipements, etc.)
- Gérer des **clients internes**
- Créer et consulter des **réservations**
- Afficher un **récapitulatif clair et structuré** des réservations
- Éviter les conflits grâce à un **statut de réservation**

L’application sépare clairement :
- la gestion des **ressources**
- la gestion des **réservations**
- les **entités métier** (clients, personnes, ressources)

---

## ⚙️ Fonctionnalités principales

- 📋 Création et gestion des ressources (type, nom, responsable, contact)
- 👤 Gestion des clients
- 📅 Création de réservations associant :
  - une ressource
  - un client
  - une date
  - un statut (confirmée, annulée, etc.)
- 📊 Affichage lisible et structuré des informations
- 🧩 Architecture orientée objet claire et modulaire

---

## 🏗️ Architecture du projet

Le projet est structuré selon une **approche orientée objet**, avec une séparation claire des responsabilités :

### 📂 Enums
Contient les énumérations utilisées dans le système :
- `ResourceType` : type de ressource (Salle, Équipement, etc.)
- `ReservationStatus` : état d’une réservation (Confirmée, Annulée, …)

### 📂 Models
Représente les **entités métier** :
- `Client` : informations sur les clients
- `Person` : personne responsable d’une ressource
- `Ressource` : ressource réservable
- `Reservation` : lien entre client, ressource et date
- `ResourceManager` : gestion centralisée des ressources

### 📂 Services
Contient la **logique métier** :
- `ReservationService` : création, gestion et affichage des réservations

### 📄 Program.cs
Point d’entrée de l’application :
- initialise les données
- appelle les services
- affiche les informations dans la console

---

## 🛠️ Choix de conception

- ✔️ Application **console uniquement**
- ✔️ Données stockées **en mémoire**
- ✔️ Utilisation des concepts C# :
  - classes
  - énumérations
  - séparation des responsabilités
- ✔️ Code structuré, lisible et évolutif
- ✔️ Respect du cahier des charges client

---

## ▶️ Exécution du programme

### Prérequis
- .NET SDK (version récente)
- Visual Studio ou VS Code

### Lancer l’application
```bash
dotnet run

NB: README.md a été généré par chatGPT
