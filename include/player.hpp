#ifndef PLAYER_HPP
#define PLAYER_HPP

#include <string>
#include <map>
#include <stdint.h>
#include "item.hpp"

// Player header and implementation file.
// There isn't a *.cpp for this file, this is single-header

class Player {
    public:
        std::string pl_name;
        // Item -> item
        // int -> quantity of items
        // hardcoded item stack limit: 255
        std::map<Item, unsigned int> pl_inventory;
        signed int pl_health_current;   // current hp
        signed int pl_health_max;       // health upper limit
        unsigned int pl_attack;         // be like Heavy, punch your problems
        unsigned int pl_defense;        // buff, unbreakable
        unsigned int pl_intellect;      // magic!
        float pl_luck;                  // that's right, luck is a stat

        // XP + level stuffs
        uint8_t pl_level;
        uint16_t pl_current_xp;
        uint16_t pl_xp_to_advance;
        uint32_t pl_total_xp;

    private:
};

/*****************************************************************************/
/* IMPLEMENTATION */

#endif // player.hpp