/*
 * File: eventHandler.cpp
 * Author: MarkAtk
 * Date: 09.10.2018
 *
 * MIT License
 *
 * Copyright (c) 2018 Rage-MP-C-SDK
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 */

#include "eventHandler.h"

#include <iostream>

std::map<eventType_t, void *> _callbacks;

void RegisterEventHandler(eventType_t type, void *callback) {
    _callbacks[type] = callback;
}

void UnregisterEventHandler(eventType_t type) {
    auto callback = _callbacks.find(type);
    if (callback == _callbacks.end()) {
        return;
    }

    _callbacks.erase(callback);
}

rage::IEntityHandler *EventHandler::GetEntityHandler() {
    return this;
}

rage::IPlayerHandler *EventHandler::GetPlayerHandler() {
    return this;
}

rage::IVehicleHandler *EventHandler::GetVehicleHandler() {
    return this;
}

rage::IColshapeHandler *EventHandler::GetColshapeHandler() {
    return this;
}

rage::ICheckpointHandler *EventHandler::GetCheckpointHandler() {
    return this;
}

rage::IBlipHandler *EventHandler::GetBlipHandler() {
    return this;
}

rage::IStreamerHandler *EventHandler::GetStreamerHandler() {
    return this;
}

rage::ITickHandler* EventHandler::GetTickHandler() {
    return this;
}

void EventHandler::OnEntityCreated(rage::IEntity *entity) {
    executeCallback(EVENT_TYPE_ENTITY_CREATED, entity);
}

void EventHandler::OnEntityDestroyed(rage::IEntity *entity) {
    executeCallback(EVENT_TYPE_ENTITY_DESTROYED, entity);
}

void EventHandler::OnEntityModelChange(rage::IEntity *entity, rage::hash_t oldModel) {
    executeCallback(EVENT_TYPE_ENTITY_MODEL_CHANGED, oldModel);
}

void EventHandler::OnPlayerJoin(rage::IPlayer *player) {
    executeCallback(EVENT_TYPE_PLAYER_JOIN, player);
}

void EventHandler::OnPlayerReady(rage::IPlayer *player) {
    executeCallback(EVENT_TYPE_PLAYER_READY, player);
}

void EventHandler::OnPlayerQuit(rage::IPlayer *player, rage::exit_t type, const char *reason) {
    executeCallback(EVENT_TYPE_PLAYER_QUIT, player, type, reason);
}

void EventHandler::OnPlayerCommand(rage::IPlayer *player, const std::u16string &command) {
    executeCallback(EVENT_TYPE_PLAYER_COMMAND, player, command.c_str());
}

void EventHandler::OnPlayerChat(rage::IPlayer *player, const std::u16string &text) {
    executeCallback(EVENT_TYPE_PLAYER_CHAT, player, text.c_str());
}

void EventHandler::OnPlayerDeath(rage::IPlayer *player, rage::hash_t reason, rage::IPlayer *killer) {
    executeCallback(EVENT_TYPE_PLAYER_DEATH, player, reason, killer);
}

void EventHandler::OnPlayerSpawn(rage::IPlayer *player) {
    executeCallback(EVENT_TYPE_PLAYER_SPAWN, player);
}

void EventHandler::OnPlayerDamage(rage::IPlayer *player, float healthLoss, float armorLoss) {
    executeCallback(EVENT_TYPE_PLAYER_DAMAGE, player, healthLoss, armorLoss);
}

void EventHandler::OnPlayerWeaponChange(rage::IPlayer *player, rage::hash_t oldWeapon, rage::hash_t newWeapon) {
    executeCallback(EVENT_TYPE_PLAYER_WEAPON_CHANGED, player, oldWeapon, newWeapon);
}

void EventHandler::OnPlayerRemoteEvent(rage::IPlayer *player, uint64_t eventNameHash, const rage::args_t &args) {
    executeCallback(EVENT_TYPE_PLAYER_REMOTE_EVENT, player, eventNameHash, args);
}

void EventHandler::OnPlayerStartEnterVehicle(rage::IPlayer *player, rage::IVehicle *vehicle, uint8_t seatId) {
    executeCallback(EVENT_TYPE_PLAYER_START_ENTER_VEHICLE, player, vehicle, seatId);
}

void EventHandler::OnPlayerEnterVehicle(rage::IPlayer *player, rage::IVehicle *vehicle, uint8_t seatId) {
    executeCallback(EVENT_TYPE_PLAYER_ENTER_VEHICLE, player, vehicle, seatId);
}

void EventHandler::OnPlayerStartExitVehicle(rage::IPlayer *player, rage::IVehicle *vehicle) {
    executeCallback(EVENT_TYPE_PLAYER_START_EXIT_VEHICLE, player, vehicle);
}

void EventHandler::OnPlayerExitVehicle(rage::IPlayer *player, rage::IVehicle *vehicle) {
    executeCallback(EVENT_TYPE_PLAYER_EXIT_VEHICLE, player, vehicle);
}

void EventHandler::OnVehicleDeath(rage::IVehicle *vehicle, rage::hash_t hash, rage::IPlayer *killer) {
    executeCallback(EVENT_TYPE_VEHICLE_DEATH, vehicle, hash, killer);
}

void EventHandler::OnVehicleSirenToggle(rage::IVehicle *vehicle, bool toggle) {
    executeCallback(EVENT_TYPE_VEHICLE_SIREN_TOGGLE, vehicle, toggle);
}

void EventHandler::OnVehicleHornToggle(rage::IVehicle *vehicle, bool toggle) {
    executeCallback(EVENT_TYPE_VEHICLE_HORN_TOGGLE, vehicle, toggle);
}

void EventHandler::OnTrailerAttached(rage::IVehicle *vehicle, rage::IVehicle *trailer) {
    executeCallback(EVENT_TYPE_VEHCILE_TRAILER_ATTACHED, vehicle, trailer);
}

void EventHandler::OnVehicleDamage(rage::IVehicle *vehicle, float bodyHealthLoss, float engineHealthLoss) {
    executeCallback(EVENT_TYPE_VEHICLE_DAMAGE, vehicle, bodyHealthLoss, engineHealthLoss);
}

void EventHandler::OnPlayerEnterColshape(rage::IPlayer *player, rage::IColshape *colshape) {
    executeCallback(EVENT_TYPE_PLAYER_ENTER_COLSHAPE, player, colshape);
}

void EventHandler::OnPlayerExitColshape(rage::IPlayer *player, rage::IColshape *colshape) {
    executeCallback(EVENT_TYPE_PLAYER_EXIT_COLSHAPE, player, colshape);
}

void EventHandler::OnPlayerEnterCheckpoint(rage::IPlayer *player, rage::ICheckpoint *checkpoint) {
    executeCallback(EVENT_TYPE_PLAYER_ENTER_CHECKPOINT, player, checkpoint);
}

void EventHandler::OnPlayerExitCheckpoint(rage::IPlayer *player, rage::ICheckpoint *checkpoint) {
    executeCallback(EVENT_TYPE_PLAYER_EXIT_CHECKPOINT, player, checkpoint);
}

void EventHandler::OnPlayerCreateWaypoint(rage::IPlayer *player, const rage::vector3 &position) {
    executeCallback(EVENT_TYPE_PLAYER_CREATE_WAYPOINT, player, position);
}

void EventHandler::OnPlayerReachWaypoint(rage::IPlayer *player) {
    executeCallback(EVENT_TYPE_PLAYER_REACH_WAYPOINT, player);
}

void EventHandler::OnPlayerStreamIn(rage::IPlayer *player, rage::IPlayer *forplayer) {
    executeCallback(EVENT_TYPE_PLAYER_STREAM_IN, player, forplayer);
}

void EventHandler::OnPlayerStreamOut(rage::IPlayer *player, rage::IPlayer *forplayer) {
    executeCallback(EVENT_TYPE_PLAYER_STREAM_OUT, player, forplayer);
}

void EventHandler::Tick() {
    executeCallback(EVENT_TYPE_TICK);
}
