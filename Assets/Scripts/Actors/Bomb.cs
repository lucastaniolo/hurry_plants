// Add timer to explode the bomb
// Countdown starts as soon as a player picks up the bomb
// Time to explode varies, designer must be able to set it via inspector
// Countdown must have a visual feedback (not defined yet)
// Bomb respawn after explosion, unless it explodes a crate
// Explosion affects nearby actors:
// - Player: kill and respawn
// - HumanNPC: kill and respawn
// - Other bomb: explode and respawn
// - Crate (objective): destroy

﻿public class Bomb : PickUpElement<Crate>
{
}
