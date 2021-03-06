// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

﻿using System.Runtime.Serialization;
using Elasticsearch.Net.Utf8Json;

namespace Nest
{
	/// <summary>
	/// A token filter of type edgeNGram.
	/// </summary>
	public interface IEdgeNGramTokenFilter : ITokenFilter
	{
		/// <summary>
		/// Defaults to 2.
		/// </summary>
		[DataMember(Name ="max_gram")]
		[JsonFormatter(typeof(NullableStringIntFormatter))]
		int? MaxGram { get; set; }

		/// <summary>
		/// Defaults to 1.
		/// </summary>
		[DataMember(Name ="min_gram")]
		[JsonFormatter(typeof(NullableStringIntFormatter))]
		int? MinGram { get; set; }

		/// <summary>
		/// Either front or back. Defaults to front.
		/// </summary>
		[DataMember(Name ="side")]
		EdgeNGramSide? Side { get; set; }
	}

	/// <inheritdoc />
	public class EdgeNGramTokenFilter : TokenFilterBase, IEdgeNGramTokenFilter
	{
		public EdgeNGramTokenFilter() : base("edge_ngram") { }

		/// <inheritdoc />
		public int? MaxGram { get; set; }

		/// <inheritdoc />
		public int? MinGram { get; set; }

		/// <inheritdoc />
		public EdgeNGramSide? Side { get; set; }
	}

	/// <inheritdoc />
	public class EdgeNGramTokenFilterDescriptor
		: TokenFilterDescriptorBase<EdgeNGramTokenFilterDescriptor, IEdgeNGramTokenFilter>, IEdgeNGramTokenFilter
	{
		protected override string Type => "edge_ngram";
		int? IEdgeNGramTokenFilter.MaxGram { get; set; }

		int? IEdgeNGramTokenFilter.MinGram { get; set; }
		EdgeNGramSide? IEdgeNGramTokenFilter.Side { get; set; }

		/// <inheritdoc />
		public EdgeNGramTokenFilterDescriptor MinGram(int? minGram) => Assign(minGram, (a, v) => a.MinGram = v);

		/// <inheritdoc />
		public EdgeNGramTokenFilterDescriptor MaxGram(int? maxGram) => Assign(maxGram, (a, v) => a.MaxGram = v);

		/// <inheritdoc />
		public EdgeNGramTokenFilterDescriptor Side(EdgeNGramSide? side) => Assign(side, (a, v) => a.Side = v);
	}
}
