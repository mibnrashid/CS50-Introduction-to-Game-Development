

BattleStatsState = Class{__includes = BaseState}

function BattleStatsState:init(taketurnstate)
    self.taketurnstate = taketurnstate
    self.battleMenu = Menu {
        x = VIRTUAL_WIDTH - 300,
        y = VIRTUAL_HEIGHT - 64,
        width = 300,
        height = 64,
        on = false,
        items = {
            {
                text = '*HP  ' .. tostring(self.taketurnstate.playerPokemon.baseHP) .. '+' .. tostring(self.taketurnstate.playerPokemon.HP - self.taketurnstate.playerPokemon.baseHP) .. '=' .. tostring(self.taketurnstate.playerPokemon.HP) .. ' *Attack  ' .. tostring(self.taketurnstate.playerPokemon.baseAttack) .. '+' .. tostring(self.taketurnstate.playerPokemon.attack - self.taketurnstate.playerPokemon.baseAttack) .. '=' .. tostring(self.taketurnstate.playerPokemon.attack)
            },
            {
            	text = '*Defense  ' .. tostring(self.taketurnstate.playerPokemon.baseDefense) .. '+' .. tostring(self.taketurnstate.playerPokemon.defense - self.taketurnstate.playerPokemon.baseDefense) .. '=' .. tostring(self.taketurnstate.playerPokemon.defense) .. ' *Speed  ' .. tostring(self.taketurnstate.playerPokemon.baseSpeed) .. '+' .. tostring(self.taketurnstate.playerPokemon.speed - self.taketurnstate.playerPokemon.baseSpeed) .. '=' .. tostring(self.taketurnstate.playerPokemon.speed)
            }
        }
    }
end

function BattleStatsState:update(dt)
    self.battleMenu:update(dt)


    if love.keyboard.wasPressed('space') or love.keyboard.wasPressed('return') then
    	self.taketurnstate:fadeOutWhite()
    	gStateStack:pop()
    	self.taketurnstate.playerPokemon.baseHP = self.taketurnstate.playerPokemon.HP
    	self.taketurnstate.playerPokemon.baseDefense = self.taketurnstate.playerPokemon.defense
    	self.taketurnstate.playerPokemon.baseAttack = self.taketurnstate.playerPokemon.attack
		self.taketurnstate.playerPokemon.baseSpeed = self.taketurnstate.playerPokemon.speed
    end
end

function BattleStatsState:render()
    self.battleMenu:render()
end