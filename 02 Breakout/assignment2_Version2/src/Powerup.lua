
Powerup = Class{}


function Powerup:init(skin)
    self.width = 16
    self.height = 16

    self.x = math.random(8, VIRTUAL_WIDTH - 16)
    self.y = -16

    self.dy = 50

    self.skin = skin

    self.inPlay = false

    self.lock = true
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
	if self.inPlay == true then
    	self.y = self.y + self.dy * dt
    else
	    self.x = math.random(8, VIRTUAL_WIDTH - 16)
	    self.y = -16
	end
end

function Powerup:render()
    	love.graphics.draw(gTextures['main'], gFrames['powerups'][self.skin],
      	  self.x, self.y)
end