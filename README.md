# COMP3329 Group Project

### &nbsp;&nbsp;Instruction :
1. Open the Scene at "Assets\Scenes\Movement"
2. If "Player Prefab" in Launcher is missing, put "Assets\Resources\User" in it
3. Hold "Tab" to open the control menu 
4. InnoShow : change photon verser code
5. Github MainVersion : 1-128 + Camera effect(dash, barrier, blur, hit, death)
5. Github subVersion : 1-128 + Arean 
5. Github supplySpawnVersion : 1-151 + Supply logic rewrite(152) 
5. Github GasVersion : 1-151 + 153-170
5. Github ThreeAtOneVersion : 1-151 + 153-170 + Camera effect + Arean

### &nbsp;&nbsp;Common potential bugs :
1. Should show in all players' view => only show to player who do it (try PunRPC)
3. Should only happen on Player A => happen on all Player (try photoView.IsMine)
4. Only Player A can do it when Player A fullfil the condition => Player B can do it when Player A fullfil the condition (try photoView.IsMine)

### &nbsp;&nbsp;To-do-list :
1. [End scene] Match result recording system 
6. [End scene] press button to rename (Kelvin)
20. [ // ] Player random spawing system (Kelvin)
23. [Supply] Everything in supply sponding system excel (Amy)
24. [Supply] Change different supply's color (Amy)
25. [optional] change player skin (Bryan)
34. [ // ] Show choosen grenade (Bryan)

### &nbsp;&nbsp;To-do-store :
1. [sound] Start scene music (???)
2. [sound] End scene music (???)
42. [sound] background music (???)
40. [sound] supply spawing sound effect (???)
41. [sound] player death sound effect (elden ring)
43. [sound] red,yellow explosion sound effect (PUBG)
44. [sound] green grenade gas emition sound effect (APEX/valorant/AOT)
44. [sound] green grenade gas explode sound effect (APEX/valorant/AOT)
46. [sound] inside water sound effect (AOT)
48. [sound] remote grenade setting sound effect (BTOOM)

### &nbsp;&nbsp;Temporary unsolvable bug :
1. Solve Explode effect retain **Bug**                <-solved 
</br> - destory function should put inside the effect
4. Solve Multiplayer delay(~0.25s) **Bug**
6. Solve have error message when explode with barrier **Bug**
9. dahs to other player **Bug** 
11. player1 entered name will show on player2 screen **Bug** (have extrem high chance to broke the death message system when you try to fix it) (related script : jsonrw, deadReason)
7. [ // ] Solve Player residual **Bug** ^
8. Solve player-grenade no collision **Bug**
8. Dash towards gas, body will emit toward a direction with extrem high speed, and cant back to normall location when restart **bug**
9. win/lose message sometime not showup **BUG**

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
53. [Cracker Grenade] Solve mid-air explodion **Bug** 
54. [Remote grenade] choose Remote grenade by number key 
54. [Remote grenade] throw Remote grenade
55. [Remote grenade] Remote grenade pink **Bug**
56. [Remote grenade] Remote grenade mid-air **Bug** 
57. [Remote grenade] Remote grenade self-explodion **Bug**
45. [Remote grenade] Cant throw again **Bug**
34. [Remote grenade] activate Remote grenade
10. [Remote grenade] make explode time lock 
11. [Remote grenade] Synchronize Remote grenade count
11. [Remote grenade] Change remote grenade from detory to hide+tp
12. [Remote grenade] Remote grenade multiplayer **Bug**
13. [Remote grenade] Remote grenade hide non-Synchronized **Bug**
57. [Remote grenade] Remote grenade time icon
57. [Remote grenade] Remote grenade time icon v2
57. [Remote grenade] Remote grenade time icon function
42. [ // ] end game loop **Bug**
43. [Remote grenade] Remote grenade press 1 icon **Bug**
50. [Remote grenade] Test multiplayer Remote grenade icon function
56. [Remote grenade] refill Remote grenade 
23. [Remote grenade] create multi-Remote grenade 
23. [Remote grenade] Test multiplayer with multi-Remote grenade 
56. [Remote grenade] refill multi-Remote grenade 
56. [Remote grenade] Test multiplayer with refill multi-Remote grenade 
57. [Remote grenade] Remote grenade pass through ground **Bug**
58. [Remote grenade] Remote grenade cant kill **Bug**
59. [Remote grenade] Explode Remote grenade after death **Bug**
60. [Remote grenade] Explode Remote grenade after death error message **Bug**
61. [Remote grenade] Remote grenade press 1 icon **Bug**
62. [Remote grenade] Round 2 Remote grenade setup fail **Bug**
63. [Remote grenade] enlarge explodsion radius 
64. [Remote grenade] enlarge explodsion effect 
65. [Remote grenade] Remote grenade explodsion effect non-Synchronized **Bug**
66. [Remote grenade] lock x,z.posiiton after collision 
67. [Gas grenade] choose Gas grenade by number key
68. [Gas grenade] copy stuffs from Cracker Grenade for Gas grenade 
69. [Gas grenade] find gas effect 
70. [Gas grenade] close explodion effect for Gas grenade
71. [Gas grenade] create gas effect for Gas grenade
72. [Gas grenade] edit gas effect
73. [Gas grenade] gas loop explosion **Bug**
73. [Gas grenade] find gas effect v2 
73. [Gas grenade] edit gas effect v2 
73. [Gas grenade] put gas effects to the Gas grenade 
73. [Gas grenade] emit gas when gas grenade stop
73. [Gas grenade] gas effect extrem lag **Bug**
73. [Gas grenade] disable first gas effect
75. [Gas grenade] move too slow never stop **Bug** 
76. [Gas grenade] downward emit gas bug **Bug** 
77. [Gas grenade] change how first gas effect disappaer
78. [Gas grenade] change how second gas effect disappaer
14. [Gas grenade] add damage area 
15. [Barrier] barrier vs ocean alive **Bug** 
16. [End scene] dead by what message 
16. [End scene] complete death message from cracker grenade
16. [End scene] complete all death message
16. [Start scene] player cant have same name
15. [Start scene] Solve name input defected **Bug** (by text cleaning)
15. [Start scene] Same name error message
15. [Start scene] wait player message
15. [Start scene] wait player gif
15. [Start scene] block input before all player open the game 
15. [Start scene] block input before all player open the game error message
15. [Start scene] block move before all player generated
15. [Start scene] block attack before all player generated 
15. [Start scene] block dash before all player generated
15. [Start scene] block barrier before all player generated
34. [Control menu] Control menu 
35. [Control menu] block control menu when end game 
16. [End scene] restart and rename icon 
18. [Supply] SupplySpawner will spawn supply with respect to coordinates given
16. [Restart System] destroy all empty object with special tag after 3 second 
16. [Restart System] destroy all gas efffect related stuffs after 3 second
16. [Restart System] show win/lose 
16. [Restart System] cut and insert cutscene 
16. [Restart System] change color of restart button when press d 
16. [Restart System] show wait for enemy message when press d
16. [Restart System] detect if all player pressed d
16. [Restart System] activate cut scene
16. [Restart System] end game close remote grenade
16. [Restart System] hide all ui during cut scene  
16. [Restart System] reset user parameter
16. [Restart System] solve cut scene not always showup **Bug** 
16. [Restart System] close crosshair in cutscene 
16. [Restart System] solve ui not showup after cutscene **Bug**
16. [Restart System] solve restart twice no win/lose **Bug**
16. [Restart System] solve restart twice no death message **Bug**
16. [Restart System] solve restart twice no cut scene **Bug**
16. [Restart System] transpot player when restart





