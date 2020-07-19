--[[
    GD50
    Legend of Zelda

    Author: Colton Ogden
    cogden@cs50.harvard.edu
]]

GAME_OBJECT_DEFS = {
    ['switch'] = {
        type = 'switch',
        texture = 'switches',
        frame = 2,
        width = 16,
        height = 16,
        solid = false,
        defaultState = 'unpressed',
        states = {
            ['unpressed'] = {
                frame = 2
            },
            ['pressed'] = {
                frame = 1
            }
        }
    },
    ['hearts'] = {
        type = 'hearts',
        texture = 'hearts',
        frame = 5,
        width = 16,
        height = 16,
        solid = false,
        defaultState = 'first',
        states = {
            ['first'] = {
                frame = 5
            }
        }
    },
    ['pot'] = {
        -- TODO
        type = 'pot',
        texture = 'tiles',
        frame = 14,
        width = 16,
        height = 16,
        solid = true,
        defaultState = '3',
        states = {
            ['1'] = {
                frame = 14
            },
            ['2'] = {
                frame = 15
            },
            ['3'] = {
                frame = 16
            },
            ['4'] = {
                frame = 33
            },
            ['5'] = {
                frame = 34
            },
            ['6'] = {
                frame = 35
            }         
        }
    }
}