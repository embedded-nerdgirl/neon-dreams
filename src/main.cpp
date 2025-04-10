#include <SDL2/SDL.h>
#include <SDL2/SDL_ttf.h>
#include <iostream>
#include "returns.hpp"

int main(void) {
    if (SDL_Init(SDL_INIT_VIDEO | SDL_INIT_TIMER | SDL_INIT_AUDIO ) != 0) {
        std::cerr << "SDL_Init error: " << SDL_GetError() << std::endl;
        return EXIT_FAIL;
    }

    if (TTF_Init() != 0) {
        std::cerr << "TTF_Init error: " << TTF_GetError() << std::endl;
        SDL_Quit();
        return EXIT_FAIL;
    }

    SDL_Window* window = SDL_CreateWindow(
        "Neon Dreams",
        SDL_WINDOWPOS_CENTERED,
        SDL_WINDOWPOS_CENTERED,
        640, 380,
        SDL_WINDOW_SHOWN
    );

    SDL_Renderer* renderer = SDL_CreateRenderer(
        window,
        -1,
        SDL_RENDERER_ACCELERATED | SDL_RENDERER_PRESENTVSYNC
    );

    if (!window || !renderer) {
        std::cerr << "Setup error: " << SDL_GetError() << std::endl;
        if (!renderer) {
            SDL_DestroyWindow(window);
            SDL_Quit();
            return EXIT_FAIL;
        }
        if (!window) {
            SDL_Quit();
            return EXIT_FAIL;
        }
        return EXIT_FAIL;
    }

    TTF_Font* font = TTF_OpenFont("assets/fonts/pixeled.ttf", 12);
    if (!font) {
        std::cerr << "Font Load Error: " << TTF_GetError() << std::endl;
        SDL_DestroyRenderer(renderer);
        SDL_DestroyWindow(window);
        TTF_Quit();
        SDL_Quit();
        return 1;
    }

    bool is_running = true;
    SDL_Event event;

    Uint32 last_time = SDL_GetTicks();
    int frames = 0;
    float fps = 0.0f;

    while (is_running) {
        Uint32 current_time = SDL_GetTicks();
        frames++;

        if (current_time - last_time >= 1000) {
            fps = frames * 1000.0f / (current_time - last_time);
            frames = 0;
            last_time = current_time;
        }

        while (SDL_PollEvent(&event)) {
            if (event.type == SDL_QUIT) is_running = false;
        }

        SDL_SetRenderDrawColor(renderer, 25, 25, 25, 255);
        SDL_RenderClear(renderer);

        // Render FPS text
        SDL_Color color = {255, 255, 255};
        std::string fpsText = "FPS: " + std::to_string(static_cast<int>(fps));
        SDL_Surface* surface = TTF_RenderText_Solid(font, fpsText.c_str(), color);
        SDL_Texture* texture = SDL_CreateTextureFromSurface(renderer, surface);

        SDL_Rect dest;
        dest.x = 10;
        dest.y = 10;
        dest.w = surface->w;
        dest.h = surface->h;

        SDL_RenderCopy(renderer, texture, nullptr, &dest);
        SDL_FreeSurface(surface);
        SDL_DestroyTexture(texture);

        SDL_RenderPresent(renderer);
    }

    SDL_DestroyRenderer(renderer);
    SDL_DestroyWindow(window);
    SDL_Quit();
    return EXIT_OK;
}