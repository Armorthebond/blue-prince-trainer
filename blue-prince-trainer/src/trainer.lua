local memory = require("src.memory")

local trainer = {}

local process_handle = nil

local HP_ADDRESS = 0x00A1B2C0
local GOLD_ADDRESS = 0x00A1B2C8

function trainer.find_process(name)
    return memory.find_process(name)
end

function trainer.attach(pid)
    process_handle = memory.open_process(pid)
end

function trainer.read_hp()
    if not process_handle then return nil end
    return memory.read_int(process_handle, HP_ADDRESS)
end

function trainer.set_hp(value)
    if not process_handle then return end
    memory.write_int(process_handle, HP_ADDRESS, value)
end

function trainer.read_gold()
    if not process_handle then return nil end
    return memory.read_int(process_handle, GOLD_ADDRESS)
end

function trainer.set_gold(value)
    if not process_handle then return end
    memory.write_int(process_handle, GOLD_ADDRESS, value)
end

return trainer