

PlayerPotLiftState = Class{__includes = BaseState}


function PlayerPotLiftState:init(player, dungeon)
    self.player = player
    self.dungeon = dungeon

    self.player:changeAnimation('potlift-' .. self.player.direction)
end

function PlayerPotLiftState:update(dt)

    if self.player.currentAnimation.timesPlayed > 0 then        
    	self.player:changeState('potwalk')
        self.player.currentAnimation.timesPlayed = 0

    end
end

function PlayerPotLiftState:render()
    local anim = self.player.currentAnimation
    love.graphics.draw(gTextures[anim.texture], gFrames[anim.texture][anim:getCurrentFrame()],
        math.floor(self.player.x - self.player.offsetX), math.floor(self.player.y - self.player.offsetY))
end