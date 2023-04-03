# COMP3329 Group Project

*1. Remade prefab for supply crates ("Assets/Resources/Supply")*

*2. ~~Used imported shader "Ocias/Standard" for materials "CreateCap_0_7" & "Crate_0_7" (for fading out)~~ Back to Autodesk Interactive*

*3. Changed scripts to accomodate for spawning logic*

---

### &nbsp;&nbsp;Instruction :

1. Open the Scene at "Assets\Scenes\Movement"
2. If "Player Prefab" in Launcher is missing, put "Assets\Resources\User" in it

### &nbsp;&nbsp;Common potential bugs :

1. Should show in all players' view => only show to player who do it (try PunRPC)
2. Should only happen on Player A => happen on all Player (try photoView.IsMine)
3. Only Player A can do it when Player A fullfil the condition => Player B can do it when Player A fullfil the condition (try photoView.IsMine)

### &nbsp;&nbsp;To-do-list :

1. [End scene] blur camera after death
2. [End scene] hide camera reticle ^
3. [End scene] show win/lose after blur ^
4. [End scene] show empty score board under win/lose ^
5. [End scene] press button to restart ^
6. [End scene] press button to Start scene ^
7. [ // ] Solve Player residual **Bug** ^
   </br> - detoryAllPlayer before game restart
8. [Arena] build a simple island \*
9. [ // ] Spawing Player on different location ^
10. [Supply] All possible Supply spawing in 3 rounds ^^
11. [Supply] Randomly ~~spawing part of them~~ (Spawning logic done, need to determine spawn points)^
13. [Supply] Keep the opened supply box on the arean ^
12. [Supply] Change amount of grenade in different supply ^
13. [Supply] Change different supply's color ^
14. [Camera effect] Barrier camera effect //yellow it
15. [Camera effect] Barrier decay camera effect ^ //crack it (decay per second, wont break, when hit get red screen)
16. [Camera effect] Dash camera effect <-DONE
17. [Camera effect] Death camera effect <-DONE
18. [Camera effect] Camera effect when get hitted <-can be done soon
19. [Camera effect] Camera effect when under water <-can be done soon (according to y-axis (lower than a value jau blue screen)) //take reference from games 深海迷航
20. [End scene] dead by what message ^
21. [ // ] Show choosen grenade ^^

### &nbsp;&nbsp;To-do-store :

1. [Arena] Complete the arena
2. [Arena] make the edge more obvious
3. [ // ] Player random spawing system
4. [BUG] Solve player-grenade no collision **Bug**
5. [End scene] Match result recording system
   </br> - need : winner/loser name, dead reason, date, battle-duration
6. [End scene] Upadte End scene with match result recording system
7. [sound] Start scene music
8. [sound] End scene music
9. [sound] supply spawing sound effect
10. [sound] player death sound effect
11. [sound] background music
12. [sound] red,yellow grenade explosion sound effect
13. [sound] green grenade gas emition sound effect
14. [sound] drop in water sound effect
15. [sound] inside water sound effect
16. [sound] ocean sound effect
17. [sound] remote grenade setting sound effect
18. [optional] two hit dead system
19. [optional] Add Grenade path
20. [optional] change player skin
21. [optional] Change sky box
22. [optional] Change ground skin
23. [optional] Change wall skin
24. [optional] Change ocean skin
25. [optional] Change oceanFloor skin
26. [ // ] cant do anything before all player arrive
27. [ // ] add wait player sence before all player arrive
28. icon effect when button is pressed
29. button no respond reason message

### &nbsp;&nbsp;Temporary unsolvable bug :

1. Solve Explode effect retain **Bug** <-solved
   </br> - destory function should put inside the effect
2. Solve Destroyed wall's scrap pass through ground **Bug**
3. Solve Multiplayer delay(~0.25s) **Bug**
4. Solve Ground transparent when view from underground **Bug**
   </br> - because it is a plane
5. Solve have error message when explode with barrier **Bug**
6. Some time player killed by enemy but player still alive in its own view
7. change caret color will also change text color
8. dahs to other player **Bug**
9. Too lag when with many Wooden chips
10. Round 3 Remote grenade icon **Bug**

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
65. [Start scene] Start scene Color Gradient
66. [Start scene] Create Start button
67. [Start scene] Activate start button
68. [Start scene] Start button press effect
69. [Start scene] Remove camera reticle
70. [Start scene] Player name entering space
71. [Start scene] Get player name
72. [Start scene] change caret color
73. [Start scene] remove placeholder when kick
74. [Start scene] Start only when name!=null
75. [Arena] Build water area
76. [Arena] Die if fall into water area
77. [Arena] keep the camera above the ocean
78. [Arena] fall slower under water
79. [Arena] edit ocean wave
80. [ // ] change gas grenade icon position
81. [Cracker Grenade] choose Cracker Grenade by number key
82. [Cracker Grenade] Solve mid-air explodion **Bug**
83. [Remote grenade] choose Remote grenade by number key
84. [Remote grenade] throw Remote grenade
85. [Remote grenade] Remote grenade pink **Bug**
86. [Remote grenade] Remote grenade mid-air **Bug**
87. [Remote grenade] Remote grenade self-explodion **Bug**
88. [Remote grenade] Cant throw again **Bug**
89. [Remote grenade] activate Remote grenade
90. [Remote grenade] make explode time lock
91. [Remote grenade] Synchronize Remote grenade count
92. [Remote grenade] Change remote grenade from detory to hide+tp
93. [Remote grenade] Remote grenade multiplayer **Bug**
94. [Remote grenade] Remote grenade hide non-Synchronized **Bug**
95. [Remote grenade] Remote grenade time icon
96. [Remote grenade] Remote grenade time icon v2
97. [Remote grenade] Remote grenade time icon function
98. [ // ] end game loop **Bug**
99. [Remote grenade] Remote grenade press 1 icon **Bug**
100. [Remote grenade] Test multiplayer Remote grenade icon function
101. [Remote grenade] refill Remote grenade
102. [Remote grenade] create multi-Remote grenade
103. [Remote grenade] Test multiplayer with multi-Remote grenade
104. [Remote grenade] refill multi-Remote grenade
105. [Remote grenade] Test multiplayer with refill multi-Remote grenade
106. [Remote grenade] Remote grenade pass through ground **Bug**
107. [Remote grenade] Remote grenade cant kill **Bug**
108. [Remote grenade] Explode Remote grenade after death **Bug**
109. [Remote grenade] Explode Remote grenade after death error message **Bug**
110. [Remote grenade] Remote grenade press 1 icon **Bug**
111. [Remote grenade] Round 2 Remote grenade setup fail **Bug**
112. [Remote grenade] enlarge explodsion radius
113. [Remote grenade] enlarge explodsion effect
114. [Remote grenade] Remote grenade explodsion effect non-Synchronized **Bug**
115. [Remote grenade] lock x,z.posiiton after collision
116. [Gas grenade] choose Gas grenade by number key
117. [Gas grenade] copy stuffs from Cracker Grenade for Gas grenade
118. [Gas grenade] find gas effect
119. [Gas grenade] close explodion effect for Gas grenade
120. [Gas grenade] create gas effect for Gas grenade
121. [Gas grenade] edit gas effect
122. [Gas grenade] gas loop explosion **Bug**
123. [Gas grenade] find gas effect v2
124. [Gas grenade] edit gas effect v2
125. [Gas grenade] put gas effects to the Gas grenade
126. [Gas grenade] emit gas when gas grenade stop
127. [Gas grenade] gas effect extrem lag **Bug**
128. [Gas grenade] disable first gas effect
129. [Gas grenade] move too slow never stop **Bug**
130. [Gas grenade] downward emit gas bug **Bug**
131. [Gas grenade] change how first gas effect disappaer
132. [Gas grenade] change how second gas effect disappaer
133. [Gas grenade] add damage area
135. [Supply] SupplySpawner will spawn supply with respect to coordinates given
