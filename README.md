# O.O.C-Freak
This is a game a small team and I made for a game jam at my college. I'm actively working on it and changes from other people are more than allowed. I hope to keep working on this and further advance it.
#Change Log for programming and major systems changes


#4/9/2022
---
##Added
- Made a new scene for starting menu
- turned canvas and game manager into prefabs.
- turned canvas and game manager into persistent singletons

##Fixed
- game manager will correctly change game states.

#4/10/2022
---
##Added
- Scripts - RocketLauncher.cs
- Added fire rate to player (can fire rocket launcher every 0.5 seconds) in Player_Atack.cs
- Added max ammo and current ammo in new script RocketLauncher.cs. new script is attached onto the rocket launcher weapon.
- Added new ui element: ammo text display. This shows current ammo only into RocketLauncher.cs

##Fixed
- none

##Bugs
- ~~Player starts with 0 health entering level 1 from starting menu~~
- ~~Player can shoot infinite ammo after depleting current ammo~~

#4/11/2022
---

##Added
- 
- 

##Fixed
- PlayerHealthManager.cs correctly working. PlayerHealthManager.cs now directly damages enemy as well as updates the health bar slider. Now calling the SetHealth() function in HealthBar.cs to update the current health each frame. Made HealthBar.cs a persistent singleton.
- 

##Bugs
- 
- 
