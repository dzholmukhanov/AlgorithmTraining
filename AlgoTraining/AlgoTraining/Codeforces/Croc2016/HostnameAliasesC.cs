using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Codeforces.Croc2016
{
    class HostnameAliasesC
    {
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                int n = fs.NextInt();
                Request[] reqs = new Request[n];
                for (int i = 0; i < n; i++)
                {
                    reqs[i] = new Request(fs.ReadLine());
                }
                reqs = reqs.OrderBy(r => r.Path).ToArray();
                Dictionary<string, Host> hostsByName = new Dictionary<string, Host>();
                Dictionary<string, LinkedList<Host>> hostsListByPaths = new Dictionary<string, LinkedList<Host>>();
                for (int i = 0; i < n; i++)
                {
                    if (!hostsByName.ContainsKey(reqs[i].Hostname)) hostsByName.Add(reqs[i].Hostname, new Host(reqs[i].Hostname));
                    hostsByName[reqs[i].Hostname].AddPath(reqs[i].Path);
                }
                int k = 0;
                foreach(KeyValuePair<string, Host> item in hostsByName)
                {
                    string paths = item.Value.GetPaths();
                    if (!hostsListByPaths.ContainsKey(paths)) hostsListByPaths.Add(paths, new LinkedList<Host>());
                    hostsListByPaths[paths].AddLast(item.Value);
                    if (hostsListByPaths[paths].Count == 2) k++;
                }
                writer.WriteLine(k);
                foreach (KeyValuePair<string, LinkedList<Host>> item in hostsListByPaths)
                {
                    if (item.Value.Count > 1)
                    {
                        foreach (Host host in item.Value)
                        {
                            writer.Write(host.Hostname + " ");
                        }
                        writer.WriteLine();
                    }
                }
            }
        }
    }
    class Host
    {
        public string Hostname;
        public HashSet<string> Paths;
        private int PathLen;
        public Host(string hostname)
        {
            Hostname = hostname;
            Paths = new HashSet<string>();
        }
        public void AddPath(string path) 
        {
            Paths.Add(path);
            PathLen += path.Length;
        }
        public string GetPaths()
        {
            StringBuilder sb = new StringBuilder(PathLen);
            foreach (string path in Paths)
            {
                sb.Append("$" + path + "$");
            }
            return sb.ToString();
        }
    }
    class Request
    {
        public string Hostname, Path;
        public Request(string url)
        {
            int hostLen = url.Length;
            for (int i = 8; i < url.Length; i++)
            {
                if (url[i] == '/')
                {
                    hostLen = i;
                    break;
                }
            }
            Hostname = url.Substring(0, hostLen);
            if (hostLen < url.Length)
            {
                Path = url.Substring(hostLen, url.Length - hostLen);
            }
            else Path = "#";
        }
    }
}
