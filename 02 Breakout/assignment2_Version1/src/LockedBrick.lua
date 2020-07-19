

LockedBrick = Class{}

function LockedBrick:init(x, y)

    self.x = 0
    self.y = 0
    self.width = 32
    self.height = 16

    self.skin = 6

    --self.inPlay = false
end


function LockedBrick:render()

    if self.inPlay == true then
        love.graphics.draw(gTextures['main'], gFrames['lockedbrick'][self.skin], self.x, self.y)
    end
end
