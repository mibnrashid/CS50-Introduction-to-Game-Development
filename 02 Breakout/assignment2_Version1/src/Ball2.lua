
Ball2 = Class{}

function Ball2:init(skin)
    self.width = 8
    self.height = 8

    self.x = VIRTUAL_WIDTH / 2 - 2
    self.y = VIRTUAL_HEIGHT / 2 - 2

    self.skin = 5

    self.inPlay = false
end

function Ball2:collides(target)
    if self.x > target.x + target.width or target.x > self.x + self.width then
        return false
    end
    if self.y > target.y + target.height or target.y > self.y + self.height then
        return false
    end 
    return true
end

function Ball2:update(dt)
    self.x = self.x + self.dx * dt
    self.y = self.y + self.dy * dt

    if self.x <= 0 then
        self.x = 0
        self.dx = -self.dx
        gSounds['wall-hit']:play()
    end

    if self.x >= VIRTUAL_WIDTH - 8 then
        self.x = VIRTUAL_WIDTH - 8
        self.dx = -self.dx
        gSounds['wall-hit']:play()
    end

    if self.y <= 0 then
        self.y = 0
        self.dy = -self.dy
        gSounds['wall-hit']:play()
    end

    if self.y >= VIRTUAL_HEIGHT + 16 then
        self.x = 0
        self.dx = 0
        self.dy = 0
        self.inPlay = false
        self.dy = math.random(-200, 200)
        self.dx = math.random(-50, -60)
    end
    if self.inPlay == false then        
        self.x = VIRTUAL_WIDTH / 2 - 2
        
        self.y = VIRTUAL_HEIGHT / 2 - 2
    end
end

function Ball2:render()
    if self.inPlay == true then
        love.graphics.draw(gTextures['main'], gFrames['balls2'][self.skin],
        self.x, self.y)
    end
end