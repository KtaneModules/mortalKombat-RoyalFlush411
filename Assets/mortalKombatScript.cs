using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using UnityEngine;
using mortalKombat;

public class mortalKombatScript : MonoBehaviour
{
		//Buttons
		public KMBombInfo Bomb;
		public KMSelectable up;
		public KMSelectable down;
		public KMSelectable left;
		public KMSelectable right;
		public KMSelectable aButton;
		public KMSelectable bButton;
		public KMSelectable cButton;

		//Audio
		public KMAudio Audio;

		//Lights
		public Renderer pass1;
		public Renderer pass2;
		public Renderer pass3;
		public Renderer fatalityText;
		public Texture passLight;
		public Texture offLight;

		//Screens
		public Renderer playerScreen;
		public Renderer opponentScreen;
		public List <Texture> characterImages;
		public List <Texture> darkCharacterImages;
		Texture playerImage;
		Texture opponentImage;
		Texture opponentDarkImage;

		//Character information
		public List <string> characterNames;
		string playerName;
		string opponentName;

		//Johnny Cage moves
		string greenFireball = "⇦⇨A";
		string shadowKick = "⇦⇨B";
		string nutCracker = "⇩⇩C";
		string greenFireballName = "Green Fireball";
		string shadowKickName = "Shadow Kick";
		string nutCrackerName = "Nut Cracker";

		//Kano moves
		string kanoball = "⇧⇩C";
		string knifeThrow = "⇨⇨B";
		string chokehold = "⇩⇦A";
		string kanoballName = "Kanoball";
		string knifeThrowName = "Knife Throw";
		string chokeholdName = "Chokehold";

		//Liu Kang moves
		string dragonFire = "⇨⇨C";
		string flyingDragonKick = "⇨⇧A";
		string airThrowKang = "⇦⇩B";
		string dragonFireName = "Dragon Fire";
		string flyingDragonKickName = "Flying Dragon Kick";
		string airThrowKangName = "Air Throw";

		//Raiden moves
		string lightningBolt = "⇦⇦B";
		string torpedo = "⇩⇨A";
		string teleport = "⇩⇧C";
		string lightningBoltName = "Lightning Bolt";
		string torpedoName = "Torpedo";
		string teleportName = "Teleport";

		//Scorpion moves
		string spear = "⇦⇦A";
		string teleportPunch = "⇦⇨C";
		string airThrowScorpion = "⇧⇧B";
		string spearName = "Spear";
		string teleportPunchName = "Teleport Punch";
		string airThrowScorpionName = "Air Throw";

		//Sonya Blade moves
		string energyRings = "⇧⇨A";
		string legGrab = "⇩⇦C";
		string squareWavePunch = "⇨⇦B";
		string energyRingsName = "Energy Rings";
		string legGrabName = "Leg Grab";
		string squareWavePunchName = "Square Wave Punch";

		//Sub-Zero moves
		string iceFreeze = "⇨⇧B";
		string slide = "⇨⇨A";
		string groundFreeze = "⇨⇩C";
		string iceFreezeName = "Ice Freeze";
		string slideName = "Slide";
		string groundFreezeName = "Ground Freeze";

		//Johnny Cage fatalities
		string deadlyUppercut = "⇩⇩⇦C⇧B";
		string torsoRip = "⇦⇦⇦BB⇧";
		string johnnyStage = "⇩⇦⇧⇩AB";
		string deadlyUppercutName = "Deadly Uppercut";
		string torsoRipName = "Torso Rip";
		string johnnyStageName = "Johnny Cage Stage";

		//Kano fatalities
		string heartRip = "A⇩B⇧⇦C";
		string eyeLaser = "⇧⇧⇨⇨CB";
		string kanoStage = "ABC⇦⇦⇧";
		string heartRipName = "Heart Rip";
		string eyeLaserName = "Eye Laser";
		string kanoStageName = "Kano Stage";

		//Liu Kang fatalities
		string butterflyFlip = "⇩⇨B⇦B⇩";
		string dragonsBite = "⇨⇨⇩A⇧C";
		string kangStage = "⇨⇨⇦⇦⇧A";
		string butterflyFlipName = "Butterfly Flip";
		string dragonsBiteName = "Dragon's Bite";
		string kangStageName = "Liu Kang Stage";

		//Raiden fatalities
		string electricDecapitation = "AA⇦⇧⇨B";
		string explosiveUppercut = "⇩⇧⇩⇧BB";
		string raidenStage = "C⇧⇦AB⇩";
		string electricDecapitationName = "Electric Decapitation";
		string explosiveUppercutName = "Explosive Uppercut";
		string raidenStageName = "Raiden Stage";

		//Scorpion fatalities
		string toasty = "⇨⇨⇨BBB";
		string spearSlice = "⇧⇧⇩⇦AC";
		string scorpionStage = "A⇨B⇩C⇩";
		string toastyName = "Toasty!";
		string spearSliceName = "Spear Slice";
		string scorpionStageName = "Scorpion Stage";

		//Sonya Blade fatalities
		string fireKiss = "⇨⇦⇦⇨CB";
		string crushKiss = "⇩⇧⇨B⇦A";
		string sonyaStage = "⇧⇧⇩⇦AC";
		string fireKissName = "Fire Kiss";
		string crushKissName = "Crush Kiss";
		string sonyaStageName = "Sonya Blade Stage";

		//Sub-Zero fatalities
		string spineRip = "⇦⇧⇨⇩CC";
		string iceShatter = "⇨⇩⇦⇧AA";
		string subZeroStage = "⇧⇨A⇦⇧B";
		string spineRipName = "Spine Rip";
		string iceShatterName = "Ice Shatter";
		string subZeroStageName = "Sub-Zero Stage";

		//Performed move & input
		string move;
		string attack1;
		string attack2;
		string attack3;
		string fatality;
		string attack1Name;
		string attack2Name;
		string attack3Name;
		string fatalityName;

		//Logging
		static int moduleIdCounter = 1;
		int moduleId;
		int stage = 1;

		//TwitchPlays
		private string TwitchHelpMessage = "Type '!{0} press' followed by either u/up, d/down, l/left, r/right, a, b or c (e.g. !{0} press up; !{0} press d)";

		public KMSelectable[] ProcessTwitchCommand(string command)
		{
				if (command.Equals("press u", StringComparison.InvariantCultureIgnoreCase) || command.Equals("press up", StringComparison.InvariantCultureIgnoreCase))
				{
						return new KMSelectable[] { up };
				}
				else if (command.Equals("press d", StringComparison.InvariantCultureIgnoreCase) || command.Equals("press down", StringComparison.InvariantCultureIgnoreCase))
				{
						return new KMSelectable[] { down };
				}
				else if (command.Equals("press l", StringComparison.InvariantCultureIgnoreCase) || command.Equals("press left", StringComparison.InvariantCultureIgnoreCase))
				{
						return new KMSelectable[] { left };
				}
				else if (command.Equals("press r", StringComparison.InvariantCultureIgnoreCase) || command.Equals("press right", StringComparison.InvariantCultureIgnoreCase))
				{
						return new KMSelectable[] { right };
				}
				else if (command.Equals("press a", StringComparison.InvariantCultureIgnoreCase))
				{
						return new KMSelectable[] { aButton };
				}
				else if (command.Equals("press b", StringComparison.InvariantCultureIgnoreCase))
				{
						return new KMSelectable[] { bButton };
				}
				else if (command.Equals("press c", StringComparison.InvariantCultureIgnoreCase))
				{
						return new KMSelectable[] { cButton };
				}
				return null;
		}
		void Awake ()
		{
				moduleId = moduleIdCounter++;
				up.OnInteract += delegate () { Onup(); return false; };
				down.OnInteract += delegate () { Ondown(); return false; };
				left.OnInteract += delegate () { Onleft(); return false; };
				right.OnInteract += delegate () { Onright(); return false; };
				aButton.OnInteract += delegate () { OnaButton(); return false; };
				bButton.OnInteract += delegate () { OnbButton(); return false; };
				cButton.OnInteract += delegate () { OncButton(); return false; };
		}

		void Start ()
		{
				PlayerSelection();
				OpponentSelection();
				AttackCalculator();
				FatalityCalculator();
		}

		//Player selection
		void PlayerSelection()
		{
				int playerSelection = UnityEngine.Random.Range(0,7);
				playerImage = characterImages[playerSelection];
				playerScreen.material.mainTexture = playerImage;
				playerName = characterNames[playerSelection];
				Debug.LogFormat("[Mortal Kombat #{0}] The selected player is {1}.", moduleId, playerName);
				characterNames.RemoveAt(playerSelection);
				characterImages.RemoveAt(playerSelection);
				darkCharacterImages.RemoveAt(playerSelection);
		}
		//Opponent selection
		void OpponentSelection()
		{
				int opponentSelection = UnityEngine.Random.Range(0,6);
				opponentImage = characterImages[opponentSelection];
				opponentDarkImage = darkCharacterImages[opponentSelection];
				opponentScreen.material.mainTexture = opponentImage;
				opponentName = characterNames[opponentSelection];
				Debug.LogFormat("[Mortal Kombat #{0}] The selected opponent is {1}.", moduleId, opponentName);
		}

		//Attack Calculator
		void AttackCalculator()
		{
				if (playerName == "Johnny Cage")
				{
						if (opponentName == "Kano")
						{
								attack1 = greenFireball;
								attack2 = nutCracker;
								attack3 = shadowKick;
								attack1Name = greenFireballName;
								attack2Name = nutCrackerName;
								attack3Name = shadowKickName;
						}
						else if (opponentName == "Liu Kang")
						{
								attack1 = shadowKick;
								attack2 = greenFireball;
								attack3 = nutCracker;
								attack1Name = shadowKickName;
								attack2Name = greenFireballName;
								attack3Name = nutCrackerName;
						}
						else if (opponentName == "Raiden")
						{
								attack1 = nutCracker;
								attack2 = shadowKick;
								attack3 = greenFireball;
								attack1Name = nutCrackerName;
								attack2Name = shadowKickName;
								attack3Name = greenFireballName;
						}
						else if (opponentName == "Scorpion")
						{
								attack1 = nutCracker;
								attack2 = greenFireball;
								attack3 = shadowKick;
								attack1Name = nutCrackerName;
								attack2Name = greenFireballName;
								attack3Name = shadowKickName;
						}
						else if (opponentName == "Sonya Blade")
						{
								attack1 = greenFireball;
								attack2 = shadowKick;
								attack3 = nutCracker;
								attack1Name = greenFireballName;
								attack2Name = shadowKickName;
								attack3Name = nutCrackerName;
						}
						if (opponentName == "Sub-Zero")
						{
								attack1 = shadowKick;
								attack2 = nutCracker;
								attack3 = greenFireball;
								attack1Name = shadowKickName;
								attack2Name = nutCrackerName;
								attack3Name = greenFireballName;
						}
				}
				else if (playerName == "Kano")
				{
						if (opponentName == "Johnny Cage")
						{
								attack1 = knifeThrow;
								attack2 = chokehold;
								attack3 = kanoball;
								attack1Name = knifeThrowName;
								attack2Name = chokeholdName;
								attack3Name = kanoballName;
						}
						else if (opponentName == "Liu Kang")
						{
								attack1 = knifeThrow;
								attack2 = kanoball;
								attack3 = chokehold;
								attack1Name = knifeThrowName;
								attack2Name = kanoballName;
								attack3Name = chokeholdName;
						}
						else if (opponentName == "Raiden")
						{
								attack1 = kanoball;
								attack2 = knifeThrow;
								attack3 = chokehold;
								attack1Name = kanoballName;
								attack2Name = knifeThrowName;
								attack3Name = chokeholdName;
						}
						else if (opponentName == "Scorpion")
						{
								attack1 = chokehold;
								attack2 = knifeThrow;
								attack3 = kanoball;
								attack1Name = chokeholdName;
								attack2Name = knifeThrowName;
								attack3Name = kanoballName;
						}
						else if (opponentName == "Sonya Blade")
						{
								attack1 = chokehold;
								attack2 = kanoball;
								attack3 = knifeThrow;
								attack1Name = chokeholdName;
								attack2Name = kanoballName;
								attack3Name = knifeThrowName;
						}
						else if (opponentName == "Sub-Zero")
						{
								attack1 = kanoball;
								attack2 = chokehold;
								attack3 = knifeThrow;
								attack1Name = kanoballName;
								attack2Name = chokeholdName;
								attack3Name = knifeThrowName;
						}
				}
				else if (playerName == "Liu Kang")
				{
						if (opponentName == "Johnny Cage")
						{
								attack1 = airThrowKang;
								attack2 = dragonFire;
								attack3 = flyingDragonKick;
								attack1Name = airThrowKangName;
								attack2Name = dragonFireName;
								attack3Name = flyingDragonKickName;
						}
						else if (opponentName == "Kano")
						{
								attack1 = dragonFire;
								attack2 = flyingDragonKick;
								attack3 = airThrowKang;
								attack1Name = dragonFireName;
								attack2Name = flyingDragonKickName;
								attack3Name = airThrowKangName;
						}
						else if (opponentName == "Raiden")
						{
								attack1 = flyingDragonKick;
								attack2 = airThrowKang;
								attack3 = dragonFire;
								attack1Name = flyingDragonKickName;
								attack2Name = airThrowKangName;
								attack3Name = dragonFireName;
						}
						else if (opponentName == "Scorpion")
						{
								attack1 = dragonFire;
								attack2 = airThrowKang;
								attack3 = flyingDragonKick;
								attack1Name = dragonFireName;
								attack2Name = airThrowKangName;
								attack3Name = flyingDragonKickName;
						}
						else if (opponentName == "Sonya Blade")
						{
								attack1 = flyingDragonKick;
								attack2 = dragonFire;
								attack3 = airThrowKang;
								attack1Name = flyingDragonKickName;
								attack2Name = dragonFireName;
								attack3Name = airThrowKangName;
						}
						else if (opponentName == "Sub-Zero")
						{
								attack1 = airThrowKang;
								attack2 = flyingDragonKick;
								attack3 = dragonFire;
								attack1Name = airThrowKangName;
								attack2Name = flyingDragonKickName;
								attack3Name = dragonFireName;
						}
				}
				else if (playerName == "Raiden")
				{
						if (opponentName == "Johnny Cage")
						{
								attack1 = teleport;
								attack2 = torpedo;
								attack3 = lightningBolt;
								attack1Name = teleportName;
								attack2Name = torpedoName;
								attack3Name = lightningBoltName;
						}
						else if (opponentName == "Kano")
						{
								attack1 = teleport;
								attack2 = lightningBolt;
								attack3 = torpedo;
								attack1Name = teleportName;
								attack2Name = lightningBoltName;
								attack3Name = torpedoName;
						}
						else if (opponentName == "Liu Kang")
						{
								attack1 = lightningBolt;
								attack2 = teleport;
								attack3 = torpedo;
								attack1Name = lightningBoltName;
								attack2Name = teleportName;
								attack3Name = torpedoName;
						}
						else if (opponentName == "Scorpion")
						{
								attack1 = torpedo;
								attack2 = teleport;
								attack3 = lightningBolt;
								attack1Name = torpedoName;
								attack2Name = teleportName;
								attack3Name = lightningBoltName;
						}
						else if (opponentName == "Sonya Blade")
						{
								attack1 = torpedo;
								attack2 = lightningBolt;
								attack3 = teleport;
								attack1Name = torpedoName;
								attack2Name = lightningBoltName;
								attack3Name = teleportName;
						}
						else if (opponentName == "Sub-Zero")
						{
								attack1 = lightningBolt;
								attack2 = torpedo;
								attack3 = teleport;
								attack1Name = lightningBoltName;
								attack2Name = torpedoName;
								attack3Name = teleportName;
						}
				}
				else if (playerName == "Scorpion")
				{
						if (opponentName == "Johnny Cage")
						{
								attack1 = spear;
								attack2 = teleportPunch;
								attack3 = airThrowScorpion;
								attack1Name = spearName;
								attack2Name = teleportPunchName;
								attack3Name = airThrowScorpionName;
						}
						else if (opponentName == "Kano")
						{
								attack1 = teleportPunch;
								attack2 = airThrowScorpion;
								attack3 = spear;
								attack1Name = teleportPunchName;
								attack2Name = airThrowScorpionName;
								attack3Name = spearName;
						}
						else if (opponentName == "Liu Kang")
						{
								attack1 = teleportPunch;
								attack2 = spear;
								attack3 = airThrowScorpion;
								attack1Name = teleportPunchName;
								attack2Name = spearName;
								attack3Name = airThrowScorpionName;
						}
						else if (opponentName == "Raiden")
						{
								attack1 = airThrowScorpion;
								attack2 = teleportPunch;
								attack3 = spear;
								attack1Name = airThrowScorpionName;
								attack2Name = teleportPunchName;
								attack3Name = spearName;
						}
						else if (opponentName == "Sonya Blade")
						{
								attack1 = airThrowScorpion;
								attack2 = spear;
								attack3 = teleportPunch;
								attack1Name = airThrowScorpionName;
								attack2Name = spearName;
								attack3Name = teleportPunchName;
						}
						else if (opponentName == "Sub-Zero")
						{
								attack1 = spear;
								attack2 = airThrowScorpion;
								attack3 = teleportPunch;
								attack1Name = spearName;
								attack2Name = airThrowScorpionName;
								attack3Name = teleportPunchName;
						}
				}
				else if (playerName == "Sonya Blade")
				{
						if (opponentName == "Johnny Cage")
						{
								attack1 = squareWavePunch;
								attack2 = legGrab;
								attack3 = energyRings;
								attack1Name = squareWavePunchName;
								attack2Name = legGrabName;
								attack3Name = energyRingsName;
						}
						else if (opponentName == "Kano")
						{
								attack1 = squareWavePunch;
								attack2 = legGrab;
								attack3 = energyRings;
								attack1Name = squareWavePunchName;
								attack2Name = legGrabName;
								attack3Name = energyRingsName;
						}
						else if (opponentName == "Liu Kang")
						{
								attack1 = energyRings;
								attack2 = squareWavePunch;
								attack3 = legGrab;
								attack1Name = energyRingsName;
								attack2Name = squareWavePunchName;
								attack3Name = legGrabName;
						}
						else if (opponentName == "Raiden")
						{
								attack1 = energyRings;
								attack2 = legGrab;
								attack3 = squareWavePunch;
								attack1Name = energyRingsName;
								attack2Name = legGrabName;
								attack3Name = squareWavePunchName;
						}
						else if (opponentName == "Scorpion")
						{
								attack1 = legGrab;
								attack2 = squareWavePunch;
								attack3 = energyRings;
								attack1Name = legGrabName;
								attack2Name = squareWavePunchName;
								attack3Name = energyRingsName;
						}
						else if (opponentName == "Sub-Zero")
						{
								attack1 = legGrab;
								attack2 = energyRings;
								attack3 = squareWavePunch;
								attack1Name = legGrabName;
								attack2Name = energyRingsName;
								attack3Name = squareWavePunchName;
						}
				}
				else if (playerName == "Sub-Zero")
				{
						if (opponentName == "Johnny Cage")
						{
								attack1 = iceFreeze;
								attack2 = groundFreeze;
								attack3 = slide;
								attack1Name = iceFreezeName;
								attack2Name = groundFreezeName;
								attack3Name = slideName;
						}
						else if (opponentName == "Kano")
						{
								attack1 = slide;
								attack2 = iceFreeze;
								attack3 = groundFreeze;
								attack1Name = slideName;
								attack2Name = iceFreezeName;
								attack3Name = groundFreezeName;
						}
						else if (opponentName == "Liu Kang")
						{
								attack1 = groundFreeze;
								attack2 = slide;
								attack3 = iceFreeze;
								attack1Name = groundFreezeName;
								attack2Name = slideName;
								attack3Name = iceFreezeName;
						}
						else if (opponentName == "Raiden")
						{
								attack1 = iceFreeze;
								attack2 = slide;
								attack3 = groundFreeze;
								attack1Name = iceFreezeName;
								attack2Name = slideName;
								attack3Name = groundFreezeName;
						}
						else if (opponentName == "Scorpion")
						{
								attack1 = slide;
								attack2 = groundFreeze;
								attack3 = iceFreeze;
								attack1Name = slideName;
								attack2Name = groundFreezeName;
								attack3Name = iceFreezeName;
						}
						else if (opponentName == "Sonya Blade")
						{
								attack1 = groundFreeze;
								attack2 = iceFreeze;
								attack3 = slide;
								attack1Name = groundFreezeName;
								attack2Name = iceFreezeName;
								attack3Name = slideName;
						}
				}
				Debug.LogFormat("[Mortal Kombat #{0}] The attack order is {1} ({2}), {3}({4}), {5}({6}).", moduleId, attack1Name, attack1, attack2Name, attack2, attack3Name, attack3);
		}

		void FatalityCalculator()
		{
					if (playerName == "Johnny Cage")
					{
							if (opponentName == "Kano" || opponentName == "Liu Kang" || opponentName == "Raiden")
							{
									if (Bomb.GetPortCount(Port.Parallel) >= 1 || Bomb.GetPortCount(Port.Serial) >= 1)
									{
											fatality = deadlyUppercut;
											fatalityName = deadlyUppercutName;
									}
									else if (Bomb.GetSerialNumberNumbers().Last() % 2 == 1)
									{
											fatality = torsoRip;
											fatalityName = torsoRipName;
									}
									else
									{
											fatality = johnnyStage;
											fatalityName = johnnyStageName;
									}
							}
							else if (opponentName == "Scorpion" || opponentName == "Sonya Blade" || opponentName == "Sub-Zero")
							{
									if (Bomb.IsIndicatorOn("CAR") || Bomb.IsIndicatorOn("CLR") || Bomb.IsIndicatorOn("MSA") || Bomb.IsIndicatorOff("BOB") || Bomb.IsIndicatorOff("NSA") || Bomb.IsIndicatorOff("FRK"))
									{
											fatality = deadlyUppercut;
											fatalityName = deadlyUppercutName;
									}
									else if (Bomb.GetBatteryCount() % 2 == 0)
									{
											fatality = torsoRip;
											fatalityName = torsoRipName;
									}
									else
									{
											fatality = johnnyStage;
											fatalityName = johnnyStageName;
									}
							}
					}
					else if (playerName == "Kano")
					{
							if (opponentName == "Johnny Cage" || opponentName == "Liu Kang" || opponentName == "Raiden")
							{
									if (Bomb.GetBatteryCount(Battery.D) > (Bomb.GetBatteryCount(Battery.AA) + Bomb.GetBatteryCount(Battery.AAx3) + Bomb.GetBatteryCount(Battery.AAx4)))
									{
											fatality = heartRip;
											fatalityName = heartRipName;
									}
									else if (Bomb.GetOffIndicators().Count() < 1)
									{
											fatality = eyeLaser;
											fatalityName = eyeLaserName;
									}
									else
									{
											fatality = kanoStage;
											fatalityName = kanoStageName;
									}
							}
							else if (opponentName == "Scorpion" || opponentName == "Sonya Blade" || opponentName == "Sub-Zero")
							{
									if (Bomb.GetSerialNumberLetters().Any(x => x == 'A' || x == 'E' || x == 'I' || x == 'O' || x == 'U'))
									{
											fatality = heartRip;
											fatalityName = heartRipName;
									}
									else if (Bomb.GetPortCount(Port.DVI) >= 1 || Bomb.GetPortCount(Port.RJ45) >= 1)
									{
											fatality = eyeLaser;
											fatalityName = eyeLaserName;
									}
									else
									{
											fatality = kanoStage;
											fatalityName = kanoStageName;
									}
							}
					}
					else if (playerName == "Liu Kang")
					{
							if (opponentName == "Johnny Cage" || opponentName == "Kano" || opponentName == "Raiden")
							{
									if (Bomb.GetOnIndicators().Count() >= 1)
									{
											fatality = butterflyFlip;
											fatalityName = butterflyFlipName;
									}
									else if (Bomb.GetPortCount(Port.StereoRCA) >= 1 || Bomb.GetPortCount(Port.PS2) >= 1)
									{
											fatality = dragonsBite;
											fatalityName = dragonsBiteName;
									}
									else
									{
											fatality = kangStage;
											fatalityName = kangStageName;
									}
							}
							else if (opponentName == "Scorpion" || opponentName == "Sonya Blade" || opponentName == "Sub-Zero")
							{
									if (new[] { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31 }.Contains(Bomb.GetSerialNumberNumbers().Sum()))
									{
											fatality = butterflyFlip;
											fatalityName = butterflyFlipName;
									}
									else if (Bomb.GetBatteryCount(Battery.D) < 1)
									{
											fatality = dragonsBite;
											fatalityName = dragonsBiteName;
									}
									else
									{
											fatality = kangStage;
											fatalityName = kangStageName;
									}
							}
					}
					else if (playerName == "Raiden")
					{
							if (opponentName == "Johnny Cage" || opponentName == "Kano" || opponentName == "Liu Kang")
							{
									if (Bomb.GetBatteryCount() <= 4)
									{
											fatality = electricDecapitation;
											fatalityName = electricDecapitationName;
									}
									else if (Bomb.GetSerialNumberLetters().Any(x => x == 'L' || x == 'P' || x == 'T'))
									{
											fatality = explosiveUppercut;
											fatalityName = explosiveUppercutName;
									}
									else
									{
											fatality = raidenStage;
											fatalityName = raidenStageName;
									}
							}
							else if (opponentName == "Scorpion" || opponentName == "Sonya Blade" || opponentName == "Sub-Zero")
							{
									if (Bomb.GetOffIndicators().Count() + Bomb.GetOnIndicators().Count() < 1)
									{
											fatality = electricDecapitation;
											fatalityName = electricDecapitationName;
									}
									else if (Bomb.GetPortCount(Port.Serial) > 1)
									{
											fatality = explosiveUppercut;
											fatalityName = explosiveUppercutName;
									}
									else
									{
											fatality = raidenStage;
											fatalityName = raidenStageName;
									}
							}
					}
					else if (playerName == "Scorpion")
					{
							if (opponentName == "Johnny Cage" || opponentName == "Kano" || opponentName == "Liu Kang")
							{
									if (Bomb.GetPortCount() > 3)
									{
											fatality = toasty;
											fatalityName = toastyName;
									}
									else if ((Bomb.GetBatteryCount(Battery.AA) + Bomb.GetBatteryCount(Battery.AAx3) + Bomb.GetBatteryCount(Battery.AAx4)) > Bomb.GetBatteryCount(Battery.D))
									{
											fatality = spearSlice;
											fatalityName = spearSliceName;
									}
									else
									{
											fatality = scorpionStage;
											fatalityName = scorpionStageName;
									}
							}
							else if (opponentName == "Raiden" || opponentName == "Sonya Blade" || opponentName == "Sub-Zero")
							{
									if (Bomb.GetSerialNumberNumbers().Last() % 2 == 0)
									{
											fatality = toasty;
											fatalityName = toastyName;
									}
									else if (Bomb.IsIndicatorOn("BOB") || Bomb.IsIndicatorOn("FRK") || Bomb.IsIndicatorOff("FRQ") || Bomb.IsIndicatorOff("CAR"))
									{
											fatality = spearSlice;
											fatalityName = spearSliceName;
									}
									else
									{
											fatality = scorpionStage;
											fatalityName = scorpionStageName;
									}
							}
					}
					else if (playerName == "Sonya Blade")
					{
							if (opponentName == "Johnny Cage" || opponentName == "Kano" || opponentName == "Liu Kang")
							{
									if ((Bomb.GetOffIndicators().Count() + Bomb.GetOnIndicators().Count()) > Bomb.GetPortCount())
									{
											fatality = fireKiss;
											fatalityName = fireKissName;
									}
									else if (Bomb.GetSerialNumberNumbers().First() > Bomb.GetBatteryCount())
									{
											fatality = crushKiss;
											fatalityName = crushKissName;
									}
									else
									{
											fatality = sonyaStage;
											fatalityName = sonyaStageName;
									}
							}
							else if (opponentName == "Raiden" || opponentName == "Scorpion" || opponentName == "Sub-Zero")
							{
									if  (Bomb.GetBatteryCount() > Bomb.GetSerialNumberNumbers().First())
									{
											fatality = fireKiss;
											fatalityName = fireKissName;
									}
									else if (Bomb.GetPortCount() > (Bomb.GetOffIndicators().Count() + Bomb.GetOnIndicators().Count()))
									{
											fatality = crushKiss;
											fatalityName = crushKissName;
									}
									else
									{
											fatality = sonyaStage;
											fatalityName = sonyaStageName;
									}
							}
					}
					else if (playerName == "Sub-Zero")
					{
							if (opponentName == "Johnny Cage" || opponentName == "Kano" || opponentName == "Liu Kang")
							{
									if (Bomb.GetSerialNumberNumbers().Sum() % 3  == 0)
									{
											fatality = spineRip;
											fatalityName = spineRipName;
									}
									else if (Bomb.GetBatteryCount() < 1)
									{
											fatality = iceShatter;
											fatalityName = iceShatterName;
									}
									else
									{
											fatality = subZeroStage;
											fatalityName = subZeroStageName;
									}
							}
							else if (opponentName == "Raiden" || opponentName == "Scorpion" || opponentName == "Sonya Blade")
							{
									if (Bomb.GetOnIndicators().Count() < 1)
									{
											fatality = spineRip;
											fatalityName = spineRipName;
									}
									else if (Bomb.GetPortCount(Port.Parallel) >= 1 || Bomb.GetPortCount(Port.StereoRCA) >= 1)
									{
											fatality = iceShatter;
											fatalityName = iceShatterName;
									}
									else
									{
											fatality = subZeroStage;
											fatalityName = subZeroStageName;
									}
							}
					}
					Debug.LogFormat("[Mortal Kombat #{0}] The correct fatality is the {1} fatality ({2}).", moduleId, fatalityName, fatality);
			}
			//Move checker
			void MoveChecker()
			{
					switch (stage)
					{
							case 1:
							if (move.Length < 3)
							{
									return;
							}
							else if (move == attack1)
							{
									Debug.LogFormat("[Mortal Kombat #{0}] You pressed {1} and hit {2} with {3}.", moduleId, move, opponentName, attack1Name);
									move = "";
									if (attack1Name == spearName)
									{
											Audio.PlaySoundAtTransform("getOverHere", transform);
									}
									else
									{
											Audio.PlaySoundAtTransform("excellent", transform);
									}
									pass1.material.mainTexture = passLight;
									stage++;
							}
							else
							{
									GetComponent<KMBombModule>().HandleStrike();
									Debug.LogFormat("[Mortal Kombat #{0}] Strike! You pressed {1}. I was expecting {2} ({3}).", moduleId, move, attack1, attack1Name);
									OpponentSelection();
									AttackCalculator();
									FatalityCalculator();
									Audio.PlaySoundAtTransform("pathetic", transform);
									move = "";
							}
							break;

							case 2:
							if (move.Length < 3)
							{
									return;
							}
							else if (move == attack2)
							{
									Debug.LogFormat("[Mortal Kombat #{0}] You pressed {1} and hit {2} with {3}.", moduleId, move, opponentName, attack2Name);
									move = "";
									if (attack2Name == spearName)
									{
											Audio.PlaySoundAtTransform("getOverHere", transform);
									}
									else
									{
											Audio.PlaySoundAtTransform("outstanding", transform);
									}
									pass2.material.mainTexture = passLight;
									stage++;
							}
							else
							{
									GetComponent<KMBombModule>().HandleStrike();
									Debug.LogFormat("[Mortal Kombat #{0}] Strike! You pressed {1}. I was expecting {2} ({3}).", moduleId, move, attack2, attack2Name);
									OpponentSelection();
									AttackCalculator();
									FatalityCalculator();
									Audio.PlaySoundAtTransform("suck", transform);
									pass1.material.mainTexture = offLight;
									move = "";
									stage = 1;
							}
							break;

							case 3:
							if (move.Length < 3)
							{
									return;
							}
							else if (move == attack3)
							{
									if (opponentName == "Sonya Blade")
									{
									Debug.LogFormat("[Mortal Kombat #{0}] You pressed {1} and hit {2} with {3}. FINISH HER!", moduleId, move, opponentName, attack3Name);
									move = "";
									Audio.PlaySoundAtTransform("finishHer", transform);
									pass3.material.mainTexture = passLight;
									stage++;
									}
									else
									{
									Debug.LogFormat("[Mortal Kombat #{0}] You pressed {1} and hit {2} with {3}. FINISH HIM!", moduleId, move, opponentName, attack3Name);
									move = "";
									Audio.PlaySoundAtTransform("finishHim", transform);
									pass3.material.mainTexture = passLight;
									stage++;
									}
							}
							else
							{
									GetComponent<KMBombModule>().HandleStrike();
									Debug.LogFormat("[Mortal Kombat #{0}] Strike! You pressed {1}. I was expecting {2} ({3}).", moduleId, move, attack3, attack3Name);
									OpponentSelection();
									AttackCalculator();
									FatalityCalculator();
									Audio.PlaySoundAtTransform("laugh", transform);
									pass1.material.mainTexture = offLight;
									pass2.material.mainTexture = offLight;
									move = "";
									stage = 1;
							}
							break;

							case 4:
							if (move.Length < 6)
							{
									return;
							}
							else if (move == fatality)
							{
									Debug.LogFormat("[Mortal Kombat #{0}] You pressed {1} and performed the {2} fatality on {3}. {4} wins. Module disarmed.", moduleId, fatality, fatalityName, opponentName, playerName);
									move = "";
									if (playerName == "Johnny Cage")
									{
											Audio.PlaySoundAtTransform("cageWins", transform);
									}
									else if (playerName == "Kano")
									{
											Audio.PlaySoundAtTransform("kanoWins", transform);
									}
									else if (playerName == "Liu Kang")
									{
											Audio.PlaySoundAtTransform("kangWins", transform);
									}
									else if (playerName == "Raiden")
									{
											Audio.PlaySoundAtTransform("raidenWins", transform);
									}
									else if (playerName == "Scorpion")
									{
											Audio.PlaySoundAtTransform("scorpionWins", transform);
									}
									else if (playerName == "Sonya Blade")
									{
											Audio.PlaySoundAtTransform("sonyaWins", transform);
									}
									else if (playerName == "Sub-Zero")
									{
											Audio.PlaySoundAtTransform("subZeroWins", transform);
									}
									fatalityText.GetComponent<Renderer>().enabled = true;
									opponentScreen.material.mainTexture = opponentDarkImage;
									GetComponent<KMBombModule>().HandlePass();
									stage++;
							}
							else
							{
									GetComponent<KMBombModule>().HandleStrike();
									Debug.LogFormat("[Mortal Kombat #{0}] Strike! You pressed {1}. I was expecting {2} ({3}).", moduleId, move, fatality, fatalityName);
									Audio.PlaySoundAtTransform("laugh", transform);
									move = "";
							}
							break;

							default:
							GetComponent<KMBombModule>().HandleStrike();
							break;
					}
		}

		//Buttons
		public void Onup()
		{
				up.AddInteractionPunch(.5f);
				Audio.PlaySoundAtTransform("up", transform);
				move += "⇧";
				MoveChecker();
		}
		public void Ondown()
		{
				down.AddInteractionPunch(.5f);
				Audio.PlaySoundAtTransform("down", transform);
				move += "⇩";
				MoveChecker();
		}
		public void Onleft()
		{
				left.AddInteractionPunch(.5f);
				Audio.PlaySoundAtTransform("left", transform);
				move += "⇦";
				MoveChecker();
		}
		public void Onright()
		{
				right.AddInteractionPunch(.5f);
				Audio.PlaySoundAtTransform("right", transform);
				move += "⇨";
				MoveChecker();
		}
		public void OnaButton()
		{
				GetComponent<KMSelectable>().AddInteractionPunch();
				Audio.PlaySoundAtTransform("punch1", transform);
				move += "A";
				MoveChecker();
		}
		public void OnbButton()
		{
				GetComponent<KMSelectable>().AddInteractionPunch();
				Audio.PlaySoundAtTransform("punch2", transform);
				move += "B";
				MoveChecker();
		}
		public void OncButton()
		{
				GetComponent<KMSelectable>().AddInteractionPunch();
				Audio.PlaySoundAtTransform("punch3", transform);
				move += "C";
				MoveChecker();
		}


}
