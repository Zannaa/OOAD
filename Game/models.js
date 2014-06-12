			var l1 = new Array("at", "is", "no", "yes", "up", "as");
			var l2 = new Array("now", "row", "the", "bus", "wow", "car");
			var l3 = new Array("next", "when", "lore", "with", "goal", "dumb");
			var l4 = new Array("where", "while", "smith", "radio", "index", "pivot");
			var l5 = new Array("server", "socket", "lumber", "dreams", "lyrics", "demons");
			var l6 = new Array("package", "glamour", "rocket", "pipeline", "oyster", "dragons", "engine", "whistle", "mummies", "momentum");
			var l7 = new Array("annihilation", "desolation", "obfuscate", "concatenate", "continue", "immolate", "walkthrough");
			
			
			
			
			// Level instance
				function LevelInstance() {
					var self = this;
					this.Aliens = new Array();
					this.score = 0;
					this.currentLetter = '';
					this.getCurrentLetter = function() {
						return self.currentLetter;
					};				
					this.notify = function() {
						for(var i = 0; i < self.Aliens.length; i++)
							self.Aliens[i].update(self);
					};
				}			
			//MainStation	
				function MainStation() {}			
				MainStation.prototype.create = function() {};
				
			//Mothership
				Mothership.prototype = new MainStation();
				Mothership.prototype.constructor = Mothership;
				Mothership.create = function(a) {
					switch(a)
					{
						case 1: return new Alien(40000, l1[Math.floor(Math.random()*l1.length)], '');
						case 2: return new Alien(40000, l2[Math.floor(Math.random()*l2.length)], '');
						case 3: return new Alien(40000, l3[Math.floor(Math.random()*l3.length)], '');
						case 4: return new Alien(40000, l4[Math.floor(Math.random()*l4.length)], '');
						case 5: return new Alien(40000, l5[Math.floor(Math.random()*l5.length)], '');
						case 6: return new Alien(40000, l6[Math.floor(Math.random()*l6.length)], '');
						case 7: return new Alien(40000, l7[Math.floor(Math.random()*l7.length)], '');
						default: return '';
					}
				}
				
				function Mothership() {}
						
			// Recruit
				function Recruit(){}				
				Recruit.prototype.update = function() {};
				
			// Alien				
				function Alien(ttl, fn, cn) {
					this.TTL = ttl;
					this.FullName = fn;
					this.CurrentName = cn;
				}
				
				Alien.prototype = new Recruit();
				Alien.prototype.constructor = Alien();
				Alien.prototype.update = function(level){
					if (level.getCurrentLetter() == this.FullName[0])
						this.CurrentName += level.getCurrentLetter();
					else if (level.getCurrentLetter() == this.FullName[this.CurrentName.length])
						this.CurrentName += level.getCurrentLetter();
					else
						this.CurrentName = '';
					
					if (this.CurrentName == this.FullName)
					{
						console.log("bingo");
						level.score = level.score + 100;
						level.Aliens.pop();
						enemyViewModel1.hide();
					}
				}
				
			//
				