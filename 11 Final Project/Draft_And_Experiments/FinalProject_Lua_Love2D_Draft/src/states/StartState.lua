--StartState

StartState = Class{__includes = BaseState}

function StartState:init()
    --gSounds['intro-music']:play()
end

function StartState:update(dt)
    --[[
        if love.keyboard.wasPressed('enter') or love.keyboard.wasPressed('return') then
            gStateStack:push(FadeInState({
                r = 255, g = 255, b = 255
            }, 1,
            function()
                gSounds['intro-music']:stop()
                self.tween:remove()

                gStateStack:pop()
                
                gStateStack:push(PlayState())
                gStateStack:push(DialogueState("" .. 
                    "Welcome to the world of 50Mon! To start fighting monsters with your own randomly assigned" ..
                    " monster, just walk in the tall grass! If you need to heal, just press 'P' in the field! " ..
                    "Good luck! (Press Enter to dismiss dialogues)"
                ))
                gStateStack:push(FadeOutState({
                    r = 255, g = 255, b = 255
                }, 1,
                function() end))
            end))
        end
    ]] --
end

function StartState:render()
    love.graphics.clear(0, 200, 200, 255)

    love.graphics.setColor(24, 24, 24, 255)
    love.graphics.setFont(gFonts['large'])
    love.graphics.printf('Sim 50', 0, VIRTUAL_HEIGHT / 2 - 72, VIRTUAL_WIDTH, 'center')
    love.graphics.setFont(gFonts['medium'])
    love.graphics.printf('Press Enter', 0, VIRTUAL_HEIGHT / 2 + 25, VIRTUAL_WIDTH, 'center')
    love.graphics.setFont(gFonts['medium'])

    love.graphics.setColor(45, 184, 45, 124)
    love.graphics.rectangle('fill', VIRTUAL_WIDTH / 8, VIRTUAL_HEIGHT / 2, 50, 100)
    love.graphics.rectangle('fill', VIRTUAL_WIDTH - VIRTUAL_WIDTH / 4, VIRTUAL_HEIGHT / 2, 50, 100)

    love.graphics.rectangle('fill', VIRTUAL_WIDTH / 8 + 12.5, VIRTUAL_HEIGHT / 2 + 20, 25, 25)
    love.graphics.rectangle('fill', VIRTUAL_WIDTH - VIRTUAL_WIDTH / 4 + 12.5, VIRTUAL_HEIGHT / 2 + 20, 25, 25)
end