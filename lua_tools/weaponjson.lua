function write_json_to_file(json_data, filename)
    local file = io.open(filename .. ".json", "w")
    if file then
        file:write(json_data)
        file:close()
    else
        print("Failed to open " .. filename .. "!")
    end
end

function main()
    io.write("Item ID: ")
    local id = io.read()
    io.write("Name: ")
    local name = io.read()
    io.write("Desc: ")
    local desc = io.read()
    io.write("Base Attributes: ")
    local base_attribute = io.read()
    io.write("Sellable (0/1): ")
    local sellable = io.read()
    io.write("Sell Value: ")
    local sell_value = io.read()
    io.write("Damage: ")
    local damage = io.read()
    io.write("Texture: ")
    local texture = io.read()

    if sellable == "0" then
        sellable = false
    elseif sellable == "1" then
        sellable = true
    end

    if tonumber(sell_value) < 0 then
        sell_value = 0
    end

    json = string.format([[
{
    "id": %s,
    "name": "%s",
    "desc": "%s",
    "base_attr": "%s",
    "sellable": %s,
    "sell_value": %d,
    "damage": %d,
    "texture": "%s"
}
    ]], id, name, desc, base_attribute, sellable, sell_value, damage, texture)
    write_json_to_file(json, id)
end

main()