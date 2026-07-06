local ui = {}

function ui.print_banner()
    print("==============================")
    print("   Blue Prince Trainer v1.0")
    print("==============================")
end

function ui.menu()
    print("\n--- Options ---")
    print("1. Read HP")
    print("2. Set HP to 9999")
    print("3. Read Gold")
    print("4. Set Gold to 99999")
    print("5. Exit")
    io.write("Choice: ")
end

function ui.info(msg)
    print("[INFO] " .. msg)
end

function ui.success(msg)
    print("[OK] " .. msg)
end

function ui.error(msg)
    print("[ERROR] " .. msg)
end

return ui