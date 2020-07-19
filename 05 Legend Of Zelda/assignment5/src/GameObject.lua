--[[
    GD50
    Legend of Zelda

    Author: Colton Ogden
    cogden@cs50.harvard.edu
]]

GameObject = Class{}

function GameObject:init(def, x, y)
    -- string identifying this object type
    self.type = def.type

    self.texture = def.texture
    self.frame = def.frame or 1

    -- whether it acts as an obstacle or not
    self.solid = def.solid
    self.done = false
    self.picked = false
    self.dead = false
    self.thrown = false
    self.thrown2 = false
    self.defx = 0
    self.defy = 0
    self.finish = false

    self.defaultState = def.defaultState
    self.state = self.defaultState
    self.states = def.states

    -- dimensions
    self.x = x
    self.y = y
    self.width = def.width
    self.height = def.height
    self.direction = 'left'

    -- default empty collision callback
    self.onCollide = function() end
end

function GameObject:update(dt)
    if self.thrown then
        if self.thrown2 == false then
            self.defx = self.x
            self.defy = self.y
            self.thrown2 = true
        end
        if self.direction == 'left' then
            self.x = self.x - 90 * dt
        elseif self.direction == 'right' then
            self.x = self.x + 90 * dt
        elseif self.direction == 'down' then
            self.y = self.y + 90 * dt
        elseif self.direction == 'up' then
            self.y = self.y - 90 * dt
        end        
        if self.x <= self.defx - 64 or self.x >= self.defx + 64
            or self.y >= self.defy + 64 or self.y <= self.defy - 64 then
                self.finish = true
        end
        if self.x <= MAP_RENDER_OFFSET_X + TILE_SIZE or self.x + self.width >= VIRTUAL_WIDTH - TILE_SIZE * 2
            or self.y <= MAP_RENDER_OFFSET_Y + TILE_SIZE - self.height / 2 or self.y + self.height >= VIRTUAL_HEIGHT - (VIRTUAL_HEIGHT - MAP_HEIGHT * TILE_SIZE) 
                + MAP_RENDER_OFFSET_Y - TILE_SIZE then
                    self.finish = true
        end
    end
    if self.finish then
        self.dead = true
    end
    if self.dead then
        self.x = -100
        self.y = -100
    end
end

function GameObject:render(adjacentOffsetX, adjacentOffsetY)
        love.graphics.draw(gTextures[self.texture], gFrames[self.texture][self.states[self.state].frame or self.frame],
    self.x + adjacentOffsetX, self.y + adjacentOffsetY)
end