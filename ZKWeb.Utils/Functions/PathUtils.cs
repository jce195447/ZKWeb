﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ZKWeb.Utils.Functions {
	/// <summary>
	/// 路径工具类
	/// </summary>
	public static class PathUtils {
		/// <summary>
		/// 获取网站根目录的路径
		/// 如当前运行的是网站则使用HttpServerUtilityBase.MapPath
		/// 如当前运行的是控制台则使用ZKWeb.Utils程序集的路径查找ZKWeb目录
		/// </summary>
		/// <returns></returns>
		public static Lazy<string> WebRoot { get; }
		= new Lazy<string>(() => {
			var webPath = HttpContextUtils.CurrentContext?.Server?.MapPath("~/");
			if (webPath != null) {
				return webPath;
			}
			var consolePath = Path.GetDirectoryName(
				Assembly.GetAssembly(typeof(PathUtils)).Location);
			return Path.GetFullPath(Path.Combine(consolePath, "../../../ZKWeb/"));
		});

		/// <summary>
		/// 安全的组合路径列表
		/// 检查参数是否为空或包含..
		/// </summary>
		/// <param name="paths">路径列表</param>
		/// <returns></returns>
		public static string SecureCombine(params string[] paths) {
			foreach (var path in paths) {
				if (path.StartsWith("/")) {
					throw new ArgumentException($"path startswith '/'");
				} else if (path.StartsWith("\\")) {
					throw new ArgumentException($"path startswith '\'");
				} else if (string.IsNullOrEmpty(path)) {
					throw new ArgumentException($"path {path} is null or empty");
				} else if (path.Contains("..")) {
					throw new ArgumentException($"path {path} contains '..'");
				}
			}
			return Path.Combine(paths);
		}

		/// <summary>
		/// 检查路径的上一级路径是否存在，不存在时创建
		/// </summary>
		/// <param name="path">路径</param>
		public static void EnsureParentDirectory(string path) {
			var parentDirectory = Path.GetDirectoryName(path);
			if (!Directory.Exists(parentDirectory)) {
				Directory.CreateDirectory(parentDirectory);
			}
		}
	}
}
