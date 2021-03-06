﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZKWeb.Utils.Functions;
using ZKWeb.Utils.UnitTest;

namespace ZKWeb.Utils.Tests.Functions {
	[UnitTest]
	class FileUtilsTest {
		public void GetSizeDisplayName() {
			Assert.Equals(FileUtils.GetSizeDisplayName(0), "0Bytes");
			Assert.Equals(FileUtils.GetSizeDisplayName(1023), "1023Bytes");
			Assert.Equals(FileUtils.GetSizeDisplayName(1024), "1KB");
			Assert.Equals(FileUtils.GetSizeDisplayName((int)(1024 * 1.5M)), "1.5KB");
			Assert.Equals(FileUtils.GetSizeDisplayName(1048576), "1MB");
			Assert.Equals(FileUtils.GetSizeDisplayName((int)(1048576 * 1.5M)), "1.5MB");
			Assert.Equals(FileUtils.GetSizeDisplayName(1073741824), "1GB");
			Assert.Equals(FileUtils.GetSizeDisplayName((int)(1073741824 * 1.5M)), "1.5GB");
		}
	}
}
