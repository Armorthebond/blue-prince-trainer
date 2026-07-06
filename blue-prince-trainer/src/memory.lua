local memory = {}

function memory.find_process(name)
    -- Stub: in real usage, enumerate processes via OS API
    -- Returns a fake PID for demonstration
    if name == "BluePrince.exe" then
        return 1234
    end
    return nil
end

function memory.open_process(pid)
    -- Stub: returns a handle object
    return { pid = pid }
end

function memory.read_int(handle, address)
    -- Stub: simulate reading a value
    return 100
end

function memory.write_int(handle, address, value)
    -- Stub: simulate writing a value
    print("[MEM] Write " .. tostring(value) .. " to address " .. string.format("0x%X", address))
end

return memory