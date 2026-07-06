local trainer = require("src.trainer")
local ui = require("src.ui")

ui.print_banner()

local process_id = trainer.find_process("BluePrince.exe")
if not process_id then
    ui.error("BluePrince.exe not found. Is the game running?")
    os.exit(1)
end

ui.info("Attached to process ID: " .. process_id)

trainer.attach(process_id)

while true do
    ui.menu()
    local choice = io.read()
    if choice == "1" then
        local hp = trainer.read_hp()
        ui.info("Current HP: " .. tostring(hp))
    elseif choice == "2" then
        trainer.set_hp(9999)
        ui.success("HP set to 9999")
    elseif choice == "3" then
        local gold = trainer.read_gold()
        ui.info("Current Gold: " .. tostring(gold))
    elseif choice == "4" then
        trainer.set_gold(99999)
        ui.success("Gold set to 99999")
    elseif choice == "5" then
        ui.info("Exiting trainer. Goodbye!")
        break
    else
        ui.error("Invalid choice. Try again.")
    end
end