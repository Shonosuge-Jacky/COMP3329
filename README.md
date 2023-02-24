# COMP3329 Group Project

### &nbsp;&nbsp;Instruction :
1. Open the Scene at "Assets\Scenes\Movement"
2. If "Player Prefab" in Launcher is missing, put "Assets\Resources\User" in it

### &nbsp;&nbsp;Common potential bugs :
1. Should show in all players' view => only show to player who do it
3. Should only happen on Player A => happen on all Player 
4. Only Player A can do it when Player A fullfil the condition => Player B can do it when Player A fullfil the condition

### &nbsp;&nbsp;To-do-list :
1. [End scene] blur camera after death <===
2. [End scene] hide camera reticle ^
3. [End scene] show win/lose after blur ^
4. [End scene] show empty score board under win/lose ^
5. [End scene] press button to restart ^
6. [End scene] press button to Start scene ^
7. (DONE)
8. (DONE)
9. (DONE)
10. (DONE)
11. [Remote grenade] refill Remote grenade ^
12. [Remote grenade] create two Remote grenade ^
13. [Remote grenade] create three Remote grenade ^
14. [Remote grenade] enlarge explodsion radius ^
15. [Remote grenade] enlarge explodsion effect ^ **
16. [Gas grenade] choose Gas grenade by number key <===
17. [Gas grenade] touch ground explode ^
18. [Gas grenade] synchronize ui counting ^
19. [Gas grenade] turn explode to gas area ^
20. [Gas grenade] make gas area enlarge as time pass ^
21. [Gas grenade] close gas ^
22. [Gas grenade] make visable gas ^ **
23. [End scene] dead by what message (after point 15 or 22)
24. [ // ] Show choosen grenade (after point 15 and 22)
36. [Arena] build a simple island <===
37. [Supply] All possible Supply spawing in 3 rounds (after point 25)
38. [Supply] Randomly spawing part of them ^
39. [Supply] Change amount of grenade in different supply ^
40. [Supply] Change different supply's color ^
41. [Supply] hide old supply ^
42. [ // ] Spawing Player on different location (after point 25)
46. [ // ] Solve Player residual **Bug** (after point 6)
</br> - detoryAllPlayer before game restart
47. [Camera effect] Barrier camera effect <===
48. [Camera effect] Dash camera effect <===
50. [Camera effect] Death camera effect <===
49. [Camera effect] Camera effect when get hitted <===
49. [Camera effect] Camera effect when under water <===
57. [Remote grenade] Remote grenade multiplayer **bug** <===
</br> - Instantiated object cant control by photonIsMine
</br> - did it by hide and tp the object 

### &nbsp;&nbsp;To-do-store :
1. [Arena] Complete the arena 
2. [Arena] make the edge more obvious
22. [ // ] Player random spawing system 
23. [BUG] Solve player-grenade no collision **Bug**
24. [End scene] Match result recording system
</br> - need : winner/loser name, dead reason, date, battle-duration
26. [End scene] Upadte End scene with match result recording system 
28. [sound] Start scene music 
29. [sound] End scene music 
31. [sound] supply spawing sound effect 
32. [sound] player death sound effect
31. [sound] background music
32. [sound] red,yellow grenade explosion sound effect
33. [sound] green grenade gas emition sound effect 
33. [sound] drop in water sound effect 
33. [sound] inside water sound effect 
33. [sound] ocean sound effect 
35. [optional] two hit dead system
36. [optional] Add Grenade path 
37. [optional] change player skin 
38. [optional] Change sky box 
39. [optional] Change ground skin 
40. [optional] Change wall skin 
41. [optional] Change ocean skin 
42. [optional] Change oceanFloor skin  
43. [ // ] cant do anything before all player arrive 

### &nbsp;&nbsp;Temporary unsolvable bug :
1. Solve Explode effect retain **Bug**
3. Solve Destroyed wall's scrap pass through ground **Bug** 
4. Solve Multiplayer delay(~0.25s) **Bug**
5. Solve Ground transparent when view from underground **Bug**
</br> - because it is a plane
6. Solve have error message when explode with barrier **Bug**
7. Some time player killed by enemy but player still alive in its own view
8. change caret color will also change text color

### &nbsp;&nbsp;What had been done :
1. [Cracker Grenade] Throw Grenade 
2. [Cracker Grenade] Grenade explosion
3. [Cracker Grenade] Solve pink Grenade **Bug**
4. [Movement] Camera movement
5. [Movement] Player movement
6. [Movement] Camera-Player Synchronization
7. [ // ] Solve sky box **Bug** 
8. [ // ] Combine Grenade and movement
9. [Cracker Grenade] Solve high speed Grenade ignore collision **Bug**
10. [Cracker Grenade] Grenade UI
11. [Cracker Grenade] Grenade UI count
12. [Supply] Pick Grenade
13. [Cracker Grenade] Solve player-grenade collision **Bug**
14. [Movement] Solve cant jump on box **Bug**
15. [Supply] Solve supply box cover **Bug** 
16. [Supply] Supply box interaction
17. [Supply] Disable Supply box movement
18. [Supply] Solve multi-Supply box **Bug**
19. [Supply] Spawn supply box
20. [Supply] Supply box spawning effect
21. [Arena] Create destoryable wall
22. [Cracker Grenade] Turn grenade to Red_Cracker Grenade
23. [Dash] Create dash function
24. [Dash] Solve dash fly **Bug**
25. [Dash] Solve dash penetrate **Bug**
26. [Dash] Solve dash fly box **Bug**
27. [Dash] Solve dash stick on the sky **Bug**
28. [Arena] Improve destroyed wall
29. [Dash] Dash coolown
30. [Dash] Dash UI
31. [Dash] Dash coolown count
32. [ // ] Spawn player
33. [Supply] Solve cant open supply **Bug**
34. [ // ] Turn into multiplayer
35. [Cracker Grenade] Solve multiplayer Grenades location non-synchronized **Bug** 
36. [Cracker Grenade] Solve multiplayer Grenades throw direction non-synchronized **Bug**
37. [Supply] Count number of player in the server 
38. [Supply] Synchronize supply box spawning time
39. [Supply] Synchronize supply box status
40. [ // ] UI for yellow and green grenade
41. [Barrier] UI for Barrier
42. [Cracker Grenade] Solve Granade explosion dont add froce to player **Bug**
43. [Cracker Grenade] Kill player by grenade
44. [End scene] Lock winner movemonet
45. [Barrier] Add Barrier
46. [Barrier] synchronize Barrier icon
47. [Barrier] block throw grenade when using barrier
48. [Barrier] Change grenade icon color when using barrier
49. [ // ] Close error box
50. [Barrier] Barrier Visual effect
51. [Barrier] Solve end game still can use Barrier **Bug**
52. [Barrier] Solve Barrier effect non-synchronized **Bug**
53. [Barrier] Solve win by attacking barrier **Bug** 
54. [Supply] Solve Supply re-open **Bug** 
55. [Supply] Solve Pick grenade through other player **Bug**
56. [Supply] Solve Supply re-pick **Bug**
57. [ // ] Solve run into different server **Bug** 
58. [Supply] Solve player2 cant open Supply **Bug** 
59. [Supply] Solve player1 open supply box through player2 **Bug**
60. [Supply] Optimalize supplyInteraction's script
61. [Supply] Solve Supply box2 animation **Bug**
62. [Start scene] a Camera filming the island 
63. [Start scene] Game title
64. [Start scene] Start scene Font Asset
64. [Start scene] Start scene Color Gradient
65. [Start scene] Create Start button 
66. [Start scene] Activate start button
67. [Start scene] Start button press effect
68. [Start scene] Remove camera reticle 
69. [Start scene] Player name entering space
70. [Start scene] Get player name
71. [Start scene] change caret color
72. [Start scene] remove placeholder when kick
73. [Start scene] Start only when name!=null
74. [Arena] Build water area 
75. [Arena] Die if fall into water area 
50. [Arena] keep the camera above the ocean
51. [Arena] fall slower under water 
51. [Arena] edit ocean wave
52. [ // ] change gas grenade icon position
53. [Cracker Grenade] choose Cracker Grenade by number key 
53. [Cracker Grenade] Solve mid-air explodion **bug** 
54. [Remote grenade] choose Remote grenade by number key 
54. [Remote grenade] throw Remote grenade
55. [Remote grenade] Remote grenade pink **bug**
56. [Remote grenade] Remote grenade mid-air **bug** 
57. [Remote grenade] Remote grenade self-explodion **bug**
45. [Remote grenade] Cant throw again **bug**
34. [Remote grenade] activate Remote grenade
10. [Remote grenade] make explode time lock 
11. [Remote grenade] Synchronize Remote grenade count
11. [Remote grenade] Change remote grenade from detory to hide+tp


