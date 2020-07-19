
Locked_Brick = Class()

function Locked_Brick:init(skin)
    self.width = 32
    self.height = 16

    self.x = VIRTUAL_WIDTH / 2 - 16
    self.y = VIRTUAL_HEIGHT / 2 - 8

    self.skin = 24

    self.num = 0
    self.inPlay = true
end

function Locked_Brick:update(dt)

	if self.num == 0 and self.inPlay == true then
		self.inPlay = false
	elseif self.num == 1 and self.inPlay == false then
		self.inPlay = true
	end
end

function Locked_Brick:render()
	if self.inPlay == true then
    	love.graphics.draw(gTextures['main'], gFrames['bricks'][self.skin],
      	  self.x, self.y)
    end
end