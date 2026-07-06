local trainer = require("src.trainer")
local memory = require("src.memory")

function test_find_process()
    assert(trainer.find_process("BluePrince.exe") ~= nil, "Should find process")
    assert(trainer.find_process("Nonexistent.exe") == nil, "Should not find missing process")
    print("[PASS] test_find_process")
end

function test_attach_and_read()
    local pid = trainer.find_process("BluePrince.exe")
    trainer.attach(pid)
    local hp = trainer.read_hp()
    assert(hp == 100, "Default stub HP should be 100")
    print("[PASS] test_attach_and_read")
end

function test_write_hp()
    local pid = trainer.find_process("BluePrince.exe")
    trainer.attach(pid)
    trainer.set_hp(9999)
    -- In stub, no return value, just ensure no error
    print("[PASS] test_write_hp")
end

function test_write_gold()
    local pid = trainer.find_process("BluePrince.exe")
    trainer.attach(pid)
    trainer.set_gold(99999)
    print("[PASS] test_write_gold")
end

test_find_process()
test_attach_and_read()
test_write_hp()
test_write_gold()
print("\nAll tests passed.")