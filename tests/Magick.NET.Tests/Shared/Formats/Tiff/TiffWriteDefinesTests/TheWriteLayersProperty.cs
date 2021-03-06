﻿// Copyright 2013-2020 Dirk Lemstra <https://github.com/dlemstra/Magick.NET/>
//
// Licensed under the ImageMagick License (the "License"); you may not use this file except in
// compliance with the License. You may obtain a copy of the License at
//
//   https://www.imagemagick.org/script/license.php
//
// Unless required by applicable law or agreed to in writing, software distributed under the
// License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND,
// either express or implied. See the License for the specific language governing permissions
// and limitations under the License.

using ImageMagick;
using ImageMagick.Formats.Tiff;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Magick.NET.Tests
{
    public partial class TiffWriteDefinesTests
    {
        [TestClass]
        public class TheWriteLayersProperty : TiffWriteDefinesTests
        {
            [TestMethod]
            public void ShouldSetTheDefineWhenSetToTrue()
            {
                using (var image = new MagickImage(Files.Builtin.Logo))
                {
                    image.Settings.SetDefines(new TiffWriteDefines()
                    {
                        WriteLayers = true,
                    });

                    Assert.AreEqual("true", image.Settings.GetDefine(MagickFormat.Tiff, "write-layers"));
                }
            }

            [TestMethod]
            public void ShouldNotSetTheDefineWhenSetToFalse()
            {
                using (var image = new MagickImage())
                {
                    image.Settings.SetDefines(new TiffWriteDefines()
                    {
                        WriteLayers = false,
                    });

                    Assert.AreEqual(null, image.Settings.GetDefine(MagickFormat.Png, "write-layers"));
                }
            }
        }
    }
}
