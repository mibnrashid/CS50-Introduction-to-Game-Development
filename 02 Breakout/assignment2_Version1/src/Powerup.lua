

Powerup = Class{}

function Powerup:init(x, y)

    self.x = 0
    self.y = 0
    self.width = 16
    self.height = 16

    self.dy = POWERUP_SPEED

    self.skin = 7

    self.inPlay = false
end

function Powerup:collides(target)
    if self.x > target.x + target.width or target.x > self.x + self.width then
        return false
    end
    if self.y > target.y + target.height or target.y > self.y + self.height then
        return false
    end 
    return true
end

function Powerup:update(dt)
    self.y = self.y + self.dy * dt

    if self.y >= VIRTUAL_HEIGHT + 16 then
    	self.y = 0
    	self.x = math.random(0, VIRTUAL_WIDTH - 8)
        self.inPlay = false
    end

    if self.inPlay == false then
        self.dy = 0
    else 
        self.dy = POWERUP_SPEED
    end
end

function Powerup:render()

    if self.inPlay == true then
        love.graphics.draw(gTextures['main'], gFrames['powerups'][self.skin], self.x, self.y)
    end
    
end