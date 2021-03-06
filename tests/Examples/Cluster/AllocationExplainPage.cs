// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using Elastic.Elasticsearch.Xunit.XunitPlumbing;
using Nest;
using System.ComponentModel;

namespace Examples.Cluster
{
	public class AllocationExplainPage : ExampleBase
	{

		[U(Skip = "Example not implemented")]
		[Description("cluster/allocation-explain.asciidoc:77")]
		public void Line77()
		{
			// tag::2663038cfc46b106edaef607d553c99c[]
			var response0 = new SearchResponse<object>();
			// end::2663038cfc46b106edaef607d553c99c[]

			response0.MatchesExample(@"GET /_cluster/allocation/explain
			{
			  ""index"": ""myindex"",
			  ""shard"": 0,
			  ""primary"": true
			}");
		}

		[U(Skip = "Example not implemented")]
		[Description("cluster/allocation-explain.asciidoc:90")]
		public void Line90()
		{
			// tag::75fb2de2b47c564833ab14049c295384[]
			var response0 = new SearchResponse<object>();
			// end::75fb2de2b47c564833ab14049c295384[]

			response0.MatchesExample(@"GET /_cluster/allocation/explain
			{
			  ""index"": ""myindex"",
			  ""shard"": 0,
			  ""primary"": false,
			  ""current_node"": ""nodeA""                         \<1>
			}");
		}

		[U(Skip = "Example not implemented")]
		[Description("cluster/allocation-explain.asciidoc:114")]
		public void Line114()
		{
			// tag::9db57741b46cc9f088cebd6a34ba147d[]
			var response0 = new SearchResponse<object>();

			var response1 = new SearchResponse<object>();
			// end::9db57741b46cc9f088cebd6a34ba147d[]

			response0.MatchesExample(@"PUT /my_index?master_timeout=1s&timeout=1s
			{""settings"": {""index.routing.allocation.include._name"": ""non_existent_node""} }");

			response1.MatchesExample(@"GET /_cluster/allocation/explain
			{
			  ""index"": ""my_index"",
			  ""shard"": 0,
			  ""primary"": true
			}");
		}
	}
}
