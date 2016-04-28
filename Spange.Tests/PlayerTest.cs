using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Spange.Models;
using Spange.Controllers;
using Xunit;

namespace Spange.Tests
{
    public class PlayerTest
    {
        [Fact]
        public void PlayerHasProperties()
        {
            var player = new Player()
            {
                Name = "Harol"
            };

            Assert.Equal("Harold", player.Name);
        }
    }
}
